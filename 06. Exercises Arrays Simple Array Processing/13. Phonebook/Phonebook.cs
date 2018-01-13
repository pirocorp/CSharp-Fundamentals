using System;

namespace _13.Phonebook
{
    class Phonebook
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            string[] phoneNumber = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            string[] names = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            string name = Console.ReadLine();
            while (name != "done")
            {
                PrintContact(names, name, phoneNumber);
                name = Console.ReadLine();
            }
        }

        private static void PrintContact(string[] names, string name, string[] phoneNumber)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (name == names[i] && i < phoneNumber.Length)
                {
                    Console.WriteLine($"{name} -> {phoneNumber[i]}");
                }
            }
        }
    }
}
