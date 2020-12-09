using System.Linq;

namespace AdventOfCode.Day.One
{
    public static class Code 
    {
        static string[] strings = System.IO.File.ReadAllLines("./Day/1/input.txt");

        public static int Answer1()
        {
            var ints = strings.Select(s => int.Parse(s)).ToArray();

            var t = ints.SelectMany(i => ints.Select(i2 => (i, i2))).First(t => t.i + t.i2 == 2020);
            return t.i * t.i2;
        }

        public static int Answer2()
        {
            var ints = strings.Select(s => int.Parse(s)).ToArray();

            var t = ints.SelectMany(i => ints.SelectMany(i2 => ints.Select(i3 => (i, i2, i3)))).First(t => t.i + t.i2 + t.i3 == 2020);
            return t.i * t.i2 * t.i3;
        }
    }
}