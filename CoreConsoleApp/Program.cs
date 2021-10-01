using System;

namespace CoreConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
            Greeter.Greet();

            Standard.StandardLibrary.StandardMethod(Console.ReadLine());
        }
    }
}
