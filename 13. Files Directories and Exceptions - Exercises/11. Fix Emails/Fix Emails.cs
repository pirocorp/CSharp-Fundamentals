using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _11.Fix_Emails
{
    class Program
    {
        static void Main()
        {
            var inputLines = File.ReadAllLines("Input.txt");
            Dictionary<string, string> emails = new Dictionary<string, string>();

            for (int i = 0; i < inputLines.Length-1; i += 2)
            {
                var name = inputLines[i];
                var email = inputLines[i + 1];
                var subEmail = email.Substring(email.Length - 2);

                if (subEmail != "us" && subEmail != "uk")
                {
                    emails.Add(name, email);
                }
            }

            emails.ToList().ForEach(x => File.AppendAllLines("Output.txt", new []{ $"{x.Key} -> {x.Value}"}));
        }
    }
}
