using System;

namespace Kata_realization
{
    public class OddEvenChecker
    {
        public void isOddEvenRange(int start, int end)
        {
            for (var i = start; i < end; i++)
            {
                if(i < 10)
                {
                    Console.WriteLine(i.ToString());
                    continue;
                }

                if (i % 2 == 0)
                    Console.WriteLine("Even");
                else
                    Console.WriteLine("Odd");
                 
            }
        }

        public bool isOddEvenDigit(int number)
        {
            if (number < 10)
                return true;
            else
                return number % 2 == 0;
        }

        public bool isOdd(int number)
        {
            return number % 2 != 0;
        }

        public bool isEven(int number)
        {
            return number % 2 == 0;
        }

        public bool isPrime(int number)
        {
            return number < 10;
        }
    }
}
