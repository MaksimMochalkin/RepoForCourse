namespace Kata_realization
{
    using System;
    using System.Text;

    public class StringCalc
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                throw new ArgumentNullException("String can not be null or empty");

            if (numbers.Length == 1)
            {
                int.TryParse(numbers, out var result);
                return result;
            }

            int sum = 0;
            var sb = new StringBuilder();
            for(var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == '-')
                    if (char.IsDigit(numbers[i + 1]))
                        sb.Append(numbers[i].ToString() + numbers[i + 1].ToString() + ", ");

                if (numbers[i] == '\n')
                    if(i == numbers.Length - 1)
                        throw new FormatException($"String contains an invalid sequence. Invalid format: 'number, separator, line feed.'");
                    else
                        if (!char.IsDigit(numbers[i + 1]))
                            throw new FormatException($"String contains an invalid sequence. Invalid format: 'number, separator, line feed.'");

                if (char.IsDigit(numbers[i]))
                    sum += int.Parse(numbers[i].ToString());
            }

            if (sb.Length > 0)
                throw new ArgumentException($"Negatives not allowed. {sb}");

            return sum;
        }
    }
}
