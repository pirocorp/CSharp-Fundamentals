namespace _01._National_Court
{
    using System;

    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                var a = int.Parse(Console.ReadLine());
                var b = int.Parse(Console.ReadLine());
                var c = int.Parse(Console.ReadLine());

                var count = int.Parse(Console.ReadLine());

                var sum = a + b + c;

                var h = Math.Ceiling(count / (double)sum);

                h += Math.Max(0, Math.Ceiling(h / 3) - 1);
                Console.WriteLine($"Time needed: {Math.Ceiling(h)}h.");

                Console.WriteLine();
            }
        }
    }
}
