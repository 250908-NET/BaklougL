using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human human = new Human();
            Human myHuman = new Human("John", "Smith");

            Console.WriteLine(human.AboutMe());
            Console.WriteLine(myHuman.AboutMe());
        }
    }
}
