namespace _01.Register_Users
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var users = new Dictionary<string, DateTime>();
            var inputData = Console.ReadLine();

            while (inputData != "end")
            {
                var tokens = inputData.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                var user = tokens[0];
                var format = "dd/MM/yyyy";

                if (!users.ContainsKey(user))
                {
                    users[user] = new DateTime();
                }

                var dateOfRegistration = DateTime.ParseExact(tokens[1], format, CultureInfo.InvariantCulture);
                users[user] = dateOfRegistration;

                inputData = Console.ReadLine();
            }

            var result = users
                .Reverse()
                .OrderBy(x => x.Value)
                .Take(5)
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .ToList();

            Console.WriteLine(String.Join(Environment.NewLine, result));
        }
    }
}
