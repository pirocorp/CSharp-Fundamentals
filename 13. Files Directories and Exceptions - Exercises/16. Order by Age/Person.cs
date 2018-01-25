using System;

namespace _16.Order_by_Age
{
    public class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public static Person Parse(string inputData)
        {
            var tokens = inputData.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            var id = tokens[1];
            var age = int.Parse(tokens[2]);

            return new Person(name, id, age);
        }
    }
}
