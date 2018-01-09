using System;

namespace _31.Safe_Manipulation
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            string[] array = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            //int n = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            while(command[0] != "END")
            {
                switch (command[0])
                {
                    case "Reverse":
                        Reverse(array);
                        //array = array.Reverse().ToArray();
                        break;
                    case "Distinct":
                        array = Distinct(array);
                        //array = array.Distinct().ToArray();
                        break;
                    case "Replace":
                        int index = int.Parse(command[1]);

                        if (index < 0 || index >= array.Length)
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }

                        Replace(array, index, command[2]);
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

                command = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            }

            string result = String.Join(" ", array);
            array = result.Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            result = String.Join(", ", array);
            Console.WriteLine(result);
        }
        
        private static void Replace(string[] array, int index, string element)
        {
            array[index] = element;
        }

        private static string[] Distinct(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == array[j] && j != i)
                    {
                        array[j] = string.Empty;
                    }
                }
            }

            char[] delimeterList = { ' ' };
            string result = String.Join(" ", array);
            array = result.Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            return array;
        }

        private static void Reverse(string[] array)
        {
            string currentElement = string.Empty;
            int n = array.Length / 2;
            for (int i = 0; i < n; i++)
            {
                currentElement = array[i];
                array[i] = array[array.Length - (1 + i)];
                array[array.Length - (1 + i)] = currentElement;
            }
        }
    }
}
