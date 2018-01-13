using System;
using System.Linq;

public class SequenceOfCommands
{
    private const char ArgumentsDelimiter = ' ';

    public static void Main()
    {
        int countOfNumbers = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();

        string command ="";

        while (!command.Equals("stop"))
        {
            string[] input = Console.ReadLine().Trim().Split(' ');

             command = input[0];

            int[] args = new int[2];

            if (command.Equals("add") ||
                command.Equals("subtract") ||
                command.Equals("multiply"))
            {
                try
                {
                    args[0] = int.Parse(input[1]);
                    args[1] = int.Parse(input[2]);
                }
                catch
                {
                    Console.WriteLine("Parsa na argumentite gurmi");
                }

                array = PerformAction(array, command, args);
            }
            else
            {
                PerformAction(array, command, args);
            }
            if (!command.Equals("stop")) PrintArray(array);
        }
    }

    static long[] PerformAction(long[] array, string action, int[] args)
    {
        int pos = args[0] -1;
        int value = args[1];
        //Console.WriteLine(action + " " + pos + " " + value);
        switch (action)
        {
            case "multiply":
                array[pos] *= value;
                break;
            case "add":
                array[pos] += value;
                break;
            case "subtract":
                array[pos] -= value;
                break;
            case "lshift":
                ArrayShiftLeft(array);
                break;
            case "rshift":
                ArrayShiftRight(array);
                break;
            default:  break;
        }

        return array;
    }

    private static void ArrayShiftRight(long[] array)
    {
        long a = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = a;
    }

    private static void ArrayShiftLeft(long[] array)
    {
        long a = array[0];
        for (int i = 1; i <= array.Length - 1; i++)
        {
            array[i - 1] = array[i];
        }
        array[array.Length - 1] = a;
    }

    private static void PrintArray(long[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
