using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28.Parking_Validation
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var parkingLotDataBase = new Dictionary<string, string>(); //<username, licensePlateNumber>

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "register":
                        var username = tokens[1];
                        var licensePlateNumber = tokens[2];
                        ProcessRegistration(parkingLotDataBase, username, licensePlateNumber);
                        break;
                    case "unregister":
                        username = tokens[1];
                        DeleteRegistration(parkingLotDataBase, username);
                        break;
                }
                
            }

            foreach (var user in parkingLotDataBase)
            {
                var username = user.Key;
                var licensePlate = user.Value;
                Console.WriteLine($"{username} => {licensePlate}");
            }
        }

        private static void DeleteRegistration(Dictionary<string, string> parkingLotDataBase, string username)
        {
            if (!parkingLotDataBase.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
                return;
            }

            parkingLotDataBase.Remove(username);
            Console.WriteLine($"user {username} unregistered successfully");
        }

        private static void ProcessRegistration(Dictionary<string, string> parkingLotDataBase, string username, string licensePlateNumber)
        {
            if (parkingLotDataBase.ContainsKey(username))
            {
                var currentLicenseNumber = parkingLotDataBase[username];
                Console.WriteLine($"ERROR: already registered with plate number {currentLicenseNumber}");
                return;
            }

            if (!LicensePlateValidation(licensePlateNumber))
            {
                Console.WriteLine($"ERROR: invalid license plate {licensePlateNumber}");
                return;
            }

            if (parkingLotDataBase.ContainsValue(licensePlateNumber))
            {
                Console.WriteLine($"ERROR: license plate {licensePlateNumber} is busy");
                return;
            }

            parkingLotDataBase[username] = licensePlateNumber;
            Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
        }

        private static bool LicensePlateValidation(string licensePlateNumber)
        {
            if (licensePlateNumber.Length != 8)
            {
                return false;
            }

            var firstTwoCharacters = licensePlateNumber.Substring(0, 2);
            var lastTwoCharacters = licensePlateNumber.Substring(licensePlateNumber.Length - 2, 2);

            if (!(firstTwoCharacters.All(c => char.IsUpper(c)) && lastTwoCharacters.All(c => char.IsUpper(c))))
            {
                return false;
            }

            var midleCharacters = new string(licensePlateNumber.Skip(2).Take(4).ToArray());

            if (!(midleCharacters.All(c => char.IsDigit(c))))
            {
                return false;
            }

            return true;
        }
    }
}
