using System;

namespace Tetris
{
    class Tetris
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string currentDirection = string.Empty;

            while (currentDirection != "exit")
            {
                currentDirection = Console.ReadLine();
                switch (currentDirection)
                {
                    case "up":
                        Up(n);
                        break;
                    case "right":
                        Right(n);
                        break;
                    case "down":
                        Down(n);
                        break;
                    case "left":
                        Left(n);
                        break;
                }
            }
        }

        static void Left(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}{1}", new string('.', n), new string('*', n));
            }

            for (int i = n; i >= 1; i--)
            {
                Console.WriteLine(new string('*', 2 * n));
            }

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}{1}", new string('.', n), new string('*', n));
            }
        }

        static void Right(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}{1}", new string('*', n), new string('.', n));
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', 2 * n));
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}{1}", new string('*', n), new string('.', n));
            }
        }

        static void Up(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}{1}{2}", new string('.', n), new string('*', n), new string('.', n));
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}", new string('*', n * 3));
            }
        }

        static void Down(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}", new string('*', n * 3));
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}{1}{2}", new string('.', n), new string('*', n), new string('.', n));
            }
        }
    }
}
