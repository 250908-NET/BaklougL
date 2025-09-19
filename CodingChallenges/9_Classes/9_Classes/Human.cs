using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human
    {

        private string lastName = "Smyth";
        private string firstName = "Pat";


        public Human(string first, string last)
        {
            firstName = first;
            lastName = last;
        }

        public Human()
        {
            
        }


        public string AboutMe()
        {
            return $"My name is {firstName} {lastName}.";
        }


    }
}




// 1. In the provided Human class: 
//     - Create a private string variable, 'lastName'. Give it a default value of "Smyth". (order of these only matters when they are parameters in the constructor.)
//     - Create a private string variable, 'firstName'. Give it a default value of "Pat".
// 2. Create a parameterized constructor that has two parameters. Use these parameters to set the firstName and lastName variables. firstName should be first, lastName should be second.
// 3. Instantiate a Human without arguments
//     - You will run into an error. Work to resolve it.    
// 4. Instantiate a Human with firstName and lastName args.
// 5. Refactor Human to create an AboutMe() method that uses interpolation and the firstName and lastName variables to return "My name is Pat Smyth." or "My name is Dick Butkus.", etc.
// 6. Call the AboutMe() method on both Humans.