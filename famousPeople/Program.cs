using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace LINQFun
{
    class famousPeople
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;
    }
    class Program
    {
        static void Main(string[] args)
        {
            IList<famousPeople> stemPeople = new List<famousPeople>() {
                new famousPeople() {Name= "Michael Faraday", BirthYear=1791,DeathYear=1867 },
                new famousPeople() {Name= "James Clerk Maxwell", BirthYear=1831,DeathYear=1879 },
                new famousPeople() {Name= "Marie Skłodowska Curie", BirthYear=1867,DeathYear=1934 },
                new famousPeople() {Name= "Katherine Johnson", BirthYear=1918,DeathYear=2020 },
                new famousPeople() {Name= "Jane C. Wright", BirthYear=1919,DeathYear=2013 },
                new famousPeople() {Name = "Tu YouYou", BirthYear= 1930 },
                new famousPeople() {Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
                new famousPeople() {Name = "Lydia Villa-Komaroff", BirthYear=1947},
                new famousPeople() {Name = "Mae C. Jemison", BirthYear=1956},
                new famousPeople() {Name = "Stephen Hawking", BirthYear=1942,DeathYear=2018 },
                new famousPeople() {Name = "Tim Berners-Lee", BirthYear=1955 },
                new famousPeople() {Name = "Terence Tao", BirthYear=1975 },
                new famousPeople() {Name = "Florence Nightingale", BirthYear=1820,DeathYear=1910 },
                new famousPeople() {Name = "George Washington Carver", DeathYear=1943 },
                new famousPeople() {Name = "Frances Allen", BirthYear=1932,DeathYear=2020 },
                new famousPeople() {Name = "Bill Gates", BirthYear=1955 }
            };

            Console.WriteLine("a.)");
            Console.WriteLine("People born after the year 1900:");
            Console.WriteLine();
            //Linq query
            IEnumerable<string> a = from person in stemPeople
                                                where person.BirthYear > 1900
                                                select person.Name;
            foreach (var name in a)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            Console.WriteLine();
         
            Console.WriteLine("b.)");
            Console.WriteLine("People who have two lowercase 'l's in their name:");
            var b = from person in stemPeople
                    let lowercaseName = person.Name.ToLower()
                    where lowercaseName.Count(c => c == 'l') == 2
                    select person.Name;

            foreach (var name in b)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("c.)");
            Console.WriteLine("Number of people with birthdays after 1950:");
            Console.WriteLine();
            int c = (from person in stemPeople
                                 where person.BirthYear > 1950
                                 select person).Count();
            Console.WriteLine(c);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("d.)");
            Console.WriteLine("People born after the year 1920 and before 2000:");
            Console.WriteLine();
            IEnumerable<string> d = from person in stemPeople
                                                where person.BirthYear > 1920 && person.BirthYear < 2000
                                                select person.Name;
            foreach (var name in d)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("e.)");
            Console.WriteLine("Sort list by BirthYear:");
            Console.WriteLine();
            var e = from person in stemPeople
                                orderby person.BirthYear
                                select person;
            foreach (var person in e)
            {
                Console.WriteLine("BirthYear: " + person.BirthYear + " " + person.Name);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("f.)");
            Console.WriteLine("People with a death year after 1960 and before 2015, sorted by name in ascending order:");
            Console.WriteLine();
            var f = from person in stemPeople
                    where person.DeathYear > 1960
                    where person.DeathYear < 2015
                    orderby person.Name
                    select person;
            foreach (var person in f)
            {
                Console.WriteLine("DeathYear: " + person.DeathYear + " " + person.Name);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
