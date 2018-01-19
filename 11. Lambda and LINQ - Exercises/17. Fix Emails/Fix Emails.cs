using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.Fix_Emails
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            Dictionary<string, string> emails = new Dictionary<string, string>();
            while (name != "stop")
            {
                string email = Console.ReadLine();
                string subEmail = email.Substring(email.Length - 2);

                if (subEmail != "us" && subEmail != "uk")
                {
                    emails.Add(name, email);
                }

                name = Console.ReadLine();
            }

            emails.ToList().ForEach(x => Console.WriteLine($"{x.Key} -> {x.Value}"));

        }

    }

}
