using System;

namespace _14.Phone
{
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

        private static void PrintMessage(string[] phoneNumber, string[] names, string s)
        {
            bool isNumber = IsNumber(phoneNumber, s);

            if (isNumber)
            {
                int elementIndex = -1;
                for (int i = 0; i < phoneNumber.Length; i++)
                {
                    if (s == phoneNumber[i]) elementIndex = i;
                }

                Console.WriteLine($"sending sms to {names[elementIndex]}...");
                int diferenceFromDigits = DiferenceFromDigits(s);
                MessageResult(diferenceFromDigits);
            }
            else
            {
                int elementIndex = -1;
                for (int i = 0; i < names.Length; i++)
                {
                    if (s == names[i]) elementIndex = i;
                }
                Console.WriteLine($"sending sms to {phoneNumber[elementIndex]}...");
                int diferenceFromDigits = DiferenceFromDigits(phoneNumber[elementIndex]);
                MessageResult(diferenceFromDigits);
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

        private static int DiferenceFromDigits(string s)
        {
            int diference = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    string element = new string(s[i], 1);
                    diference -= int.Parse(element);
                }
            }

            return diference;
        }

        private static void PrintCall(string[] phoneNumber, string[] names, string s)
        {
            bool isNumber = IsNumber(phoneNumber, s);

            if (isNumber)
            {
                int elementIndex = -1;
                for (int i = 0; i < phoneNumber.Length; i++)
                {
                    if (s == phoneNumber[i]) elementIndex = i;
                }

                Console.WriteLine($"calling {names[elementIndex]}...");
                int sumOfDigits = SumOfDigits(s);
                CallResult(sumOfDigits);
            }
            else
            {
                int elementIndex = -1;
                for (int i = 0; i < names.Length; i++)
                {
                    if (s == names[i]) elementIndex = i;
                }
                Console.WriteLine($"calling {phoneNumber[elementIndex]}...");
                int sumOfDigits = SumOfDigits(phoneNumber[elementIndex]);
                CallResult(sumOfDigits);
            }
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

        private static int SumOfDigits(string s)
        {
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    string element = new string (s[i], 1);
                    sum += int.Parse(element);
                }
            }

            return sum;
        }

        private static bool IsNumber(string[] phoneNumber, string s)
        {
            bool isNumber = false;

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (s == phoneNumber[i]) isNumber = true;
            }

            return isNumber;
        }
    }
}
