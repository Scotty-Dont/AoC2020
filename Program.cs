using System;
using System.Diagnostics;
using System.Threading;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 1;
            Console.WriteLine($"Day {day++}");
            Console.WriteLine(TimeAction(() => Day.One.Code.Answer1()));
            Console.WriteLine(Day.One.Code.Answer2());

            Console.WriteLine($"\nDay {day++}");
            Console.WriteLine(TimeAction(() => Day.Two.Code.Answer1()));
            Console.WriteLine(TimeAction(() => Day.Two.Code.Answer2()));

            Console.WriteLine($"\nDay {day++}");
            Console.WriteLine(TimeAction(() => Day.Three.Code.Answer1()));
            Console.WriteLine(TimeAction(() => Day.Three.Code.Answer2()));

            Console.WriteLine($"\nDay {day++}");
            Console.WriteLine(TimeAction(() => Day.Four.Code.Answer1()));
            Console.WriteLine(TimeAction(() => Day.Four.Code.Answer2()));

            Console.WriteLine($"\nDay {day++}");
            Console.WriteLine(TimeAction(() => Day.Five.Code.Answer1()));
            Console.WriteLine(TimeAction(() => Day.Five.Code.Answer2()));

            Console.WriteLine($"\nDay {day++}");
            Console.WriteLine(TimeAction(() => Day.Six.Code.Answer1()));
            Console.WriteLine(TimeAction(() => Day.Six.Code.Answer2()));

            Console.WriteLine($"\nDay {day++}");
            Console.WriteLine(TimeAction(() => Day.Seven.Code.Answer1()));
            Console.WriteLine(TimeAction(() => Day.Seven.Code.Answer2()));

            Console.WriteLine($"\nDay {day++}");
            Console.WriteLine(TimeAction(() => Day.Eight.Code.Answer1()));
            Console.WriteLine(TimeAction(() => Day.Eight.Code.Answer2()));

            Console.WriteLine($"\nDay {day++}");
            Console.WriteLine(TimeAction(() => Day.Nine.Code.Answer1()));
            //Console.WriteLine(TimeAction(() => Day.Nine.Code.Answer2())); //~1.5 seconds
            Console.WriteLine(TimeAction(() => Day.Nine.Code.Answer2v2())); //~0.007 seconds
        }

        public static string TimeAction<T>(Func<T> action)
        {
            var t = new Stopwatch();

            t.Start();
            var result = action();
            t.Stop();

            return $"\nAnswer: {result}\nTime: {t.Elapsed.TotalSeconds} seconds.";
        }
    }
}
