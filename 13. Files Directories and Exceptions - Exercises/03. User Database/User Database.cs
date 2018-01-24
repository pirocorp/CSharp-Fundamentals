using System;
using System.Collections.Generic;
using System.IO;

namespace _03.User_Database
{
    class Program
    {
        private static string dbPath = "users.txt";
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        private static bool isLogged = false;

        static void Main()
        {
            if (!File.Exists(dbPath))
            {
                File.Create(dbPath).Close();
            }

            var usersFromFile = File.ReadAllLines(dbPath);

            for (var i = 0; i < usersFromFile.Length; i++)
            {
                var currentUser = usersFromFile[i].Split(' ');
                var currentUsername = currentUser[0];
                var currentPasword = currentUser[1];

                users[currentUsername] = currentPasword;
            }

            var commands = File.ReadAllLines("Input.txt");

            for (var i = 0; i < commands.Length; i++)
            {
                var currentCommand = commands[i].Split(' ');

                switch (currentCommand[0])
                {
                    case "register":
                        var username = currentCommand[1];
                        var password = currentCommand[2];
                        var confirmPassword = currentCommand[3];
                        Register(username, password, confirmPassword);
                        break;
                    case "login":
                        username = currentCommand[1];
                        password = currentCommand[2];
                        Login(username, password);
                        break;
                    case "logout":
                        Logout();
                        break;
                }
            }
        }

        private static void Logout()
        {
            if (!isLogged)
            {
                Console.WriteLine($"There is no currently logged in user.");
                return;
            }

            isLogged = false;
        }

        private static void Login(string username, string password)
        {
            if (!users.ContainsKey(username))
            {
                Console.WriteLine($"There is no user with the given username.");
                return;
            }

            if (users[username] != password)
            {
                Console.WriteLine($"The password you entered is incorrect.");
                return;
            }

            if (isLogged)
            {
                Console.WriteLine($"There is already a logged in user.");
                return;
            }

            isLogged = true;
        }

        private static void Register(string username, string password, string confirmPassword)
        {
            if (users.ContainsKey(username))
            {
                Console.WriteLine($"The given username already exists.");
                return;
            }

            if (password != confirmPassword)
            {
                Console.WriteLine($"The two passwords must match.");
                return;
            }

            users[username] = password;
            var currentUser = new[] { $"{username} {password}" };
            File.AppendAllLines(dbPath, currentUser);
        }
    }
}
