using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human h1 = new Human();
            Human h2 = new Human("John", "Smith");

            Console.WriteLine(h1.AboutMe());
            Console.WriteLine(h2.AboutMe());


            Human2 h21 = new Human2("Lily", "Smith", "brown", 4);
            Human2 h22 = new Human2("Sam", "Smith", 30);
            Human2 h23 = new Human2("Peter", "Johnson", "blue");

            Console.WriteLine(h21.AboutMe2());
            Console.WriteLine(h22.AboutMe2());
            Console.WriteLine(h23.AboutMe2());


            Human2 h24 = new Human2("Tom", "Brown", "green", 25)
            {
                Weight = 200
            };

            Console.WriteLine($"Weight set to valid value: {h24.Weight}");

            h24.Weight = 450; 
            Console.WriteLine($"Weight after invalid set: {h24.Weight}");

        }
    }
}
