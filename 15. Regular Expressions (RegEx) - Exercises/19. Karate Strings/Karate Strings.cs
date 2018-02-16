namespace _19.Karate_Strings
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main() // 100/100
        {
            var input = new StringBuilder(Console.ReadLine());

            const char punch = '>';
            var punchStrength = 0;

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] != punch)
                {
                    continue;
                }

                punchStrength += int.Parse(input[i + 1].ToString());
                var index = i + 1;

                while (index < input.Length && punchStrength > 0)
                {
                    if (input[index] == punch)
                    {
                        break;
                    }

                    input.Remove(index, 1);
                    punchStrength--;
                }
            }

            Console.WriteLine(input);
        }
    }
}