using System;

namespace Calculator
{
    class Calculator
    {
        static void Main()
        {
            int numberOne = int.Parse(Console.ReadLine());
            char operatorChar = char.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            int result = 0;

            switch (operatorChar)
            {
                case '+': result = numberOne + numberTwo; Console.WriteLine($"{numberOne} {operatorChar} {numberTwo} = {result}"); break;
                case '-': result = numberOne - numberTwo; Console.WriteLine($"{numberOne} {operatorChar} {numberTwo} = {result}"); break;
                case '*': result = numberOne * numberTwo; Console.WriteLine($"{numberOne} {operatorChar} {numberTwo} = {result}"); break;
                case '/': result = numberOne / numberTwo; Console.WriteLine($"{numberOne} {operatorChar} {numberTwo} = {result}"); break;
                default: break;
            }
        }
    }
}
