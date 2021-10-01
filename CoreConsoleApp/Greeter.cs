namespace CoreConsoleApp
{
    using System;

    public class Greeter
    {
        public static void Greet()
        {
            Console.WriteLine("Enter your name");

            var name = Console.ReadLine();

            Console.WriteLine($"Hello, {name}");

            Console.ReadKey();
        }
    }
}
