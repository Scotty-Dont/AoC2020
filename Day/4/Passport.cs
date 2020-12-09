using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day.Four
{
    public class Passport
    {
        public Passport(KeyValuePair<string, string>[] keys)
        {
            this.keys = keys;
            _dict = keys.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        private string[] _requiredKeys = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        private readonly KeyValuePair<string, string>[] keys;
        private readonly Dictionary<string, string> _dict;

        /*
byr (Birth Year) - four digits; at least 1920 and at most 2002.
iyr (Issue Year) - four digits; at least 2010 and at most 2020.
eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
hgt (Height) - a number followed by either cm or in:
If cm, the number must be at least 150 and at most 193.
If in, the number must be at least 59 and at most 76.
hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
pid (Passport ID) - a nine-digit number, including leading zeroes.
         */
        Dictionary<string, Func<string, bool>> validators = new Dictionary<string, Func<string, bool>> {
                {"byr", val => int.TryParse(val, out var value) && value <= 2002 && value >= 1920 },
                {"iyr", val => int.TryParse(val, out var value) && value <= 2020 && value >= 2010 },
                {"eyr", val => int.TryParse(val, out var value) && value <= 2030 && value >= 2020 },
                {"hgt", val =>
                    (val.EndsWith("in") && int.TryParse(val.Substring(0, val.Length - 2), out var inches) && inches >= 59 && inches <= 76) ||
                    (val.EndsWith("cm") && int.TryParse(val.Substring(0, val.Length - 2), out var cm) && cm <= 193 && cm >= 150)
                },
                {"hcl", val => val.StartsWith("#") && val.Length == 7 && val.Skip(1).All(c => new []{ 'a', 'b', 'c', 'd', 'e', 'f', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }.Any(hex => hex == c)) },
                {"ecl", val => new []{"amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Any(c => c == val) },
                {"pid", val => val.Length == 9 && val.All(c => int.TryParse(new string(new char[]{ c }), out var tmp)) },
            };

        public bool IsValid => _requiredKeys.All(rk => keys.Any(k => rk == k.Key));

        public bool IsMoreValid => IsValid && validators.All(v => v.Value(_dict[v.Key]));
    }
}
