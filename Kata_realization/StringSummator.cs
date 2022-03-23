using System;
using System.Text.RegularExpressions;

namespace Kata_realization
{
    public class StringSummator
    {
        public int Sum(string num1, string num2)
        {
            if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
                throw new ArgumentNullException("String can not be null or empty");

            if(num1.Length > 1 || num2.Length > 1)
            {
                if(num1.Length > 1)
                    num1 = "0";
                if(num2.Length > 1)
                    num2 = "0";
            }
            var regex = new Regex(@"\d");
            if (regex.IsMatch(num1) && regex.IsMatch(num2))
            {
                int.TryParse(num1, out var number1);
                int.TryParse(num2, out var number2);
                return number1 + number2;
            }

            throw new ArgumentException($"One of the arguments is a letter. Num1: {num1}, Num2: {num2}");
        }
    }
}
