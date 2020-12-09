using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day.Five
{
    public static class Code
    {
        static string[] strings = System.IO.File.ReadAllLines("./Day/5/input.txt");

        public static int Answer1()
        {
            var seats = GetSeats();

            return seats.Last();
        }

        public static int Answer2()
        {
            var seats = GetSeats();

            var gappedSeat = seats.Zip(seats.Skip(1)).First(s => s.Second - s.First > 1);

            return gappedSeat.First + 1;
        }

        public static int[] GetSeats()
        {
            return strings.Select(s => Convert.ToInt32(s.Replace("F", "0").Replace("B", "1").Replace("L", "0").Replace("R", "1"), 2)).OrderBy(i => i).ToArray();
        }
    }
}
