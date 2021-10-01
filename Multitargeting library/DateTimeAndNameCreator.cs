namespace Multitargeting_library
{
    using System;

    public class DateTimeAndNameCreator
    {
        public static string DateTimeAndNameCofigurator(string name)
        {
            return $"{DateTime.UtcNow}: Hello< {name}";
        }
    }
}
