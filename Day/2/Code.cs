using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day.Two
{
    public static class Code
    {
        static string[] strings = System.IO.File.ReadAllLines("./Day/2/input.txt");
        public static int Answer1()
        {
            return strings.Select(s => s.Split('-', ' ')).Select(s => new Password(s)).Count(p => p.IsValid);
        }

        public static int Answer2()
        {
            return strings.Select(s => s.Split('-', ' ')).Select(s => new Password(s)).Count(p => p.IsValidByLocation);
        }
    }
}
