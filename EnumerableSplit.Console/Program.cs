using SawNaw.LinqExtensions.EnumerableSplit.Core;
using System;

namespace SawNaw.LinqExtensions.EnumerableSplit.Terminal
{
    public class Program
    {
        private class Person
        {
            internal string Name;
            internal string Title;

            public Person(string name, string titles)
            {
                Name = name;
                Title = titles;
            }
        }

        static void Main(string[] args)
        {
            var records = new Person[]
            {
                new Person("John", "manager" ),
                new Person("Mike Wang", "engineer"),
                new Person("Separator 1",  "NA" ),
                new Person("Wilbur", "manager" ),
                new Person("Shaun", "pilot" ),
                new Person("Separator 2", "NA" ),
                new Person("Mario", "manager" ),
            };

            var splitRecords = records.Split(r => r.Name.Contains("Separator"));

            foreach (var collection in splitRecords)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.Name} is a {item.Title}");
                }
                Console.WriteLine("***END OF COLLECTION***");
            }
        }
    }
}