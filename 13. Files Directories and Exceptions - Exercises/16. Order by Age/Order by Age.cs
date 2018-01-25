using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.Order_by_Age
{
    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine();
            var peoples = new List<Person>();

            while (inputData != "End")
            {
                peoples.Add(Person.Parse(inputData));
                inputData = Console.ReadLine();
            }

            peoples = peoples.OrderBy(x => x.Age).ToList();

            foreach (var person in peoples)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }
}
