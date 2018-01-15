using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.User_Logins
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var users = new Dictionary<string, string>();

            while (input != "login")
            {
                var inputStrings = input.Split(new[] {'-', '>'}, StringSplitOptions.RemoveEmptyEntries);
                var userName = inputStrings[0].Trim();
                var password = inputStrings[1].Trim();
                users[userName] = password;
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            var ununsuccessfulLoginAttemptsCounter = 0;

            while (input != "end")
            {
                var inputStrings = input.Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var userName = inputStrings[0].Trim();
                var password = inputStrings[1].Trim();

                if (!users.ContainsKey(userName))
                {
                    Console.WriteLine($"{userName}: login failed");
                    ununsuccessfulLoginAttemptsCounter++;
                }
                else if (users[userName] != password)
                {
                    Console.WriteLine($"{userName}: login failed");
                    ununsuccessfulLoginAttemptsCounter++;
                }
                else
                {
                    Console.WriteLine($"{userName}: logged in successfully");
                }

                input = Console.ReadLine();
            }

            if (ununsuccessfulLoginAttemptsCounter > 0)
            {
            Console.WriteLine($"unsuccessful login attempts: {ununsuccessfulLoginAttemptsCounter}");
            }
        }
    }
}
