using System;

namespace Standard
{
    public class StandardLibrary
    {
        public static string StandardMethod(string name)
        {
            return $"{DateTime.Now}: Hello, {name}!";
        }
    }
}
