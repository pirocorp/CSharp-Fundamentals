using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Animals
    {
        public class Dog
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int NumberOfLegs { get; set; }

            public static Dog Parse(string inputData)
            {
                var tokens = inputData.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                
                var result = new Dog()
                {
                    Name = tokens[0],
                    Age = int.Parse(tokens[1]),
                    NumberOfLegs = int.Parse(tokens[2])
                };
                
                return result;
            }

            public static void ProduceSound()
            {
                Console.WriteLine("I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
            }
        }

        public class Cat
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int IntelligenceQuotient { get; set; }

            public static Cat Parse(string inputData)
            {
                var tokens = inputData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var result = new Cat()
                {
                    Name = tokens[0],
                    Age = int.Parse(tokens[1]),
                    IntelligenceQuotient = int.Parse(tokens[2])
                };

                return result;
            }

            public static void ProduceSound()
            {
                Console.WriteLine("I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
            }
        }

        public class Snake
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int CrueltyCoefficient { get; set; }

            public static Snake Parse(string inputData)
            {
                var tokens = inputData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var result = new Snake()
                {
                    Name = tokens[0],
                    Age = int.Parse(tokens[1]),
                    CrueltyCoefficient = int.Parse(tokens[2])
                };

                return result;
            }

            public static void ProduceSound()
            {
                Console.WriteLine("I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home.");
            }
        }

        static void Main()
        {
            var inputData = Console.ReadLine();
            var dogsDataBase = new List<Dog>();
            var catDataBase = new List<Cat>();
            var snakeDataBase = new List<Snake>();
            var animalNamesType = new Dictionary<string, string>(); //<name, type>

            while (inputData != "I'm your Huckleberry")
            {
                var tokens = inputData.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var className = tokens[0];
                var classData = String.Join(" ", tokens.Skip(1));

                switch (className)
                {
                    case "Dog":
                        var currentDog = Dog.Parse(classData);
                        dogsDataBase.Add(currentDog);
                        var dogNname = tokens[1];
                        animalNamesType[dogNname] = "Dog";
                        break;
                    case "Cat":
                        var currentCat = Cat.Parse(classData);
                        catDataBase.Add(currentCat);
                        var catName = tokens[1];
                        animalNamesType[catName] = "Cat";
                        break;
                    case "Snake":
                        var currentSnake = Snake.Parse(classData);
                        snakeDataBase.Add(currentSnake);
                        var snakeName = tokens[1];
                        animalNamesType[snakeName] = "Snake";
                        break;
                    case "talk":
                        var name = tokens[1];
                        var typeOfAnimal = animalNamesType[name];

                        switch (typeOfAnimal)
                        {
                            case "Dog":
                                Dog.ProduceSound();
                                break;
                            case "Cat":
                                Cat.ProduceSound();
                                break;
                            case "Snake":
                                Snake.ProduceSound();
                                break;
                        }
                        break;
                }

                inputData = Console.ReadLine();
            }

            foreach (var currentDog in dogsDataBase)
            {
                Console.WriteLine($"Dog: {currentDog.Name}, Age: {currentDog.Age}, Number Of Legs: {currentDog.NumberOfLegs}");
            }

            foreach (var currentCat in catDataBase)
            {
                Console.WriteLine($"Cat: {currentCat.Name}, Age: {currentCat.Age}, IQ: {currentCat.IntelligenceQuotient}");
            }

            foreach (var currentSnake in snakeDataBase)
            {
                Console.WriteLine($"Snake: {currentSnake.Name}, Age: {currentSnake.Age}, Cruelty: {currentSnake.CrueltyCoefficient}");
            }

            //foreach (var animal in animalNamesType)
            //{
            //    var animalName = animal.Key;
            //    var animalType = animal.Value;

            //    switch (animalType)
            //    {
            //        case "Dog":
            //            var currentDog = dogsDataBase.Where(x => x.Name == animalName).First();
            //            Console.WriteLine($"Dog: {currentDog.Name}, Age: {currentDog.Age}, Number Of Legs: {currentDog.NumberOfLegs}");
            //            break;
            //        case "Cat":
            //            var currentCat = catDataBase.Where(x => x.Name == animalName).First();
            //            Console.WriteLine($"Cat: {currentCat.Name}, Age: {currentCat.Age}, IQ: {currentCat.IntelligenceQuotient}");
            //            break;
            //        case "Snake":
            //            var currentSnake = snakeDataBase.Where(x => x.Name == animalName).First();
            //            Console.WriteLine($"Snake: {currentSnake.Name}, Age: {currentSnake.Age}, Cruelty: {currentSnake.CrueltyCoefficient}");
            //            break;
            //    }
            //}
        }
    }
}
