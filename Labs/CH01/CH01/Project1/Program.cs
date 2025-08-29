using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter your age:");
            int userAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Hello {name}, you are {userAge} years old.");
        }
    }
}

