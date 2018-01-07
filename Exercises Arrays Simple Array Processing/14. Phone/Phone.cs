namespace _14.Phone
{
    using System;
    class Phone
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            string[] phoneNumber = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            string[] names = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            string[] command = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries); 
            while (command[0] != "done")
            {
                if (command.Length == 1)
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (command[0] == names[i] && i < phoneNumber.Length)
                        {
                            Console.WriteLine($"{command[0]} -> {phoneNumber[i]}");
                        }
                    }
                }
                else
                {
                    if (command[0] == "call")
                    {
                        PrintCall(phoneNumber, names, command[1]);
                    }
                    else if (command[0] == "message")
                    {
                        PrintMessage(phoneNumber, names, command[1]);
                    }
                }

                command = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static void PrintCall(string[] phoneNumber, string[] names, string element)
        {
            bool isNumber = IsNumber(phoneNumber, element);

            if (isNumber)
            {
                int elementIndex = ElementIndex(phoneNumber, element);
                Console.WriteLine($"calling {names[elementIndex]}...");
                int sumOfDigits = SumOfDigits(element);
                CallResult(sumOfDigits);
            }
            else
            {
                int elementIndex = ElementIndex(names, element);
                Console.WriteLine($"calling {phoneNumber[elementIndex]}...");
                int sumOfDigits = SumOfDigits(phoneNumber[elementIndex]);
                CallResult(sumOfDigits);
            }
        }

        private static void PrintMessage(string[] phoneNumber, string[] names, string element)
        {
            bool isNumber = IsNumber(phoneNumber, element);

            if (isNumber)
            {
                int elementIndex = ElementIndex(phoneNumber, element);
                Console.WriteLine($"sending sms to {names[elementIndex]}...");
                int diferenceFromDigits = DiferenceFromDigits(element);
                MessageResult(diferenceFromDigits);
            }
            else
            {
                int elementIndex = ElementIndex(names, element);
                Console.WriteLine($"sending sms to {phoneNumber[elementIndex]}...");
                int diferenceFromDigits = DiferenceFromDigits(phoneNumber[elementIndex]);
                MessageResult(diferenceFromDigits);
            }
        }

        private static bool IsNumber(string[] phoneNumber, string element)
        {
            bool isNumber = false;

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (element == phoneNumber[i]) isNumber = true;
            }

            return isNumber;
        }

        private static int ElementIndex(string[] phoneNumber, string element)
        {
            int elementIndex = -1;
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (element == phoneNumber[i]) elementIndex = i;
            }

            return elementIndex;
        }

        private static int SumOfDigits(string element)
        {
            int sum = 0;
            for (int i = 0; i < element.Length; i++)
            {
                if (element[i] >= '0' && element[i] <= '9')
                {
                    string str = new string(element[i], 1);
                    sum += int.Parse(str);
                }
            }

            return sum;
        }

        private static int DiferenceFromDigits(string element)
        {
            int diference = 0;
            for (int i = 0; i < element.Length; i++)
            {
                if (element[i] >= '0' && element[i] <= '9')
                {
                    string str = new string(element[i], 1);
                    diference -= int.Parse(str);
                }
            }

            return diference;
        }

        private static void CallResult(int sumOfDigits)
        {
            if (sumOfDigits % 2 == 0)
            {
                int min = sumOfDigits / 60;
                int sec = sumOfDigits % 60;
                Console.WriteLine($"call ended. duration: {min:d2}:{sec:d2}");
            }
            else
            {
                Console.WriteLine("no answer");
            }
        }

        private static void MessageResult(int diferenceFromDigits)
        {
            if (diferenceFromDigits % 2 == 0)
            {
                Console.WriteLine("meet me there");
            }
            else
            {
                Console.WriteLine("busy");
            }
        }
    }
}
