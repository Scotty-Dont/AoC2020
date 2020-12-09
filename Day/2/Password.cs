using System.Linq;

namespace AdventOfCode.Day.Two
{
    internal class Password
    {
        private readonly int min;
        private readonly int max;
        private readonly string letter;
        private readonly string password;

        public Password(string[] s)
        {
            min = int.Parse(s[0]);
            max = int.Parse(s[1]);
            letter = s[2].Trim(':');
            password = s[3];
        }

        public bool IsValid
        {
            get
            {
                int c = password.Count(c => c == letter[0]);
                return min <= c && c <= max;
            }
        }

        public bool IsValidByLocation
        {
            get
            {
                return password[min - 1] == letter[0] ^ password[max - 1] == letter[0];
            }
        }
    }
}