namespace _08.Personal_Exception
{
    using System;
    using _23.Personal_Exception;

    class Program
    {
        static void Main()
        {
            try
            {
                while (true)
                {
                    int number = int.Parse(Console.ReadLine());

                    if (number < 0)
                    {
                        throw new PersonalException();
                    }
                    Console.WriteLine(number);
                }
            }
            catch (PersonalException pe)
            {
                Console.WriteLine(pe.Message);
                return;
            }
        }
    }
}