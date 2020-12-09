using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day.Six
{
    public static class Code
    {
        static string[] strings = System.IO.File.ReadAllLines("./Day/6/input.txt");

        public static int Answer1()
        {
            var groups = GetGroups();

            return groups.Sum(g => g.DistinctPeople.Count());
        }

        public static int Answer2()
        {
            var groups = GetGroups();
            return groups.Sum(g => g.AnyoneSums);
        }

        private class Group
        {
            private readonly string[] _groupStrings;

            public Group(string[] groupStrings)
            {
                _groupStrings = groupStrings;
            }

            public IEnumerable<char> DistinctPeople => _groupStrings.SelectMany(s => s.Select(c => c)).Distinct();

            public int AnyoneSums 
            { 
                get
                {
                    var ppl = DistinctPeople;
                    return ppl.Count(p => _groupStrings.All(g => g.Contains(p)));
                } 
            }
        }

        private static List<Group> GetGroups()
        {
            int rowsToSkip = 0;
            var passports = new List<Group>();
            while (rowsToSkip <= strings.Length)
            {
                var passportStrings = strings.Skip(rowsToSkip).TakeWhile(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                rowsToSkip += passportStrings.Length + 1;

                var answers = passportStrings.SelectMany(ps => ps.Split(' ', '\n')).ToArray();
                passports.Add(new Group(answers));
            }

            return passports;
        }
    }
}
