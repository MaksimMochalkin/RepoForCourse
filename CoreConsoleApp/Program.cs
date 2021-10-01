using System;

namespace CoreConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
            // Without .Net Standard
            Greeter.Greet();

            // With .Net Standard
            Standard.StandardLibrary.StandardMethod(Console.ReadLine());
        }
    }
}
