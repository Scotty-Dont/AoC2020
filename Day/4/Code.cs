using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day.Four
{
    public static class Code
    {
        static string[] strings = System.IO.File.ReadAllLines("./Day/4/input.txt");

        public static int Answer1()
        {
            var passports = GetPassports();

            return passports.Count(p => p.IsValid);
        }

        public static int Answer2()
        {
            var passports = GetPassports();
            return passports.Count(p => p.IsMoreValid);
        }

        private static List<Passport> GetPassports()
        {
            int rowsToSkip = 0;
            List<Passport> passports = new List<Passport>();
            while (rowsToSkip <= strings.Length)
            {
                var passportStrings = strings.Skip(rowsToSkip).TakeWhile(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                rowsToSkip += passportStrings.Length + 1;

                var kvps = passportStrings.SelectMany(ps => ps.Split(' ', '\n')).Select(kvp => new KeyValuePair<string, string>(kvp.Split(':')[0], kvp.Split(':')[1])).ToArray();
                passports.Add(new Passport(kvps));
            }

            return passports;
        }
    }
}
