using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day.Nine
{
    public static class Code
    {
        static string[] strings = System.IO.File.ReadAllLines("./Day/9/input.txt");
        

        public static long Answer1()
        {
            var numbers = GetNumbers();

            for(int i = 25; i < numbers.Count; i++)
            {
                var previousNumbers = numbers.Skip(i - 25).Take(25).ToList();
                var sums = GetPairSums(previousNumbers);

                if (!sums.Contains(numbers[i]))
                    return numbers[i];
            }

            throw new Exception("No invalid number found.");
        }

        public static long Answer2()
        {
            var numbers = GetNumbers();
            var invalidNumber = Answer1();
            var range = GetRange(invalidNumber, numbers);
            return range.Min() + range.Max();
        }

        public static long Answer2v2()
        {
            var v2 = GetRangeV2(Answer1(), GetNumbers());
            return v2.Min() + v2.Max();
        }

        private static List<long> GetRange(long invalidNumber, List<long> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = 2; j < numbers.Count - i; j++)
                {
                    List<long> range = numbers.Skip(i).Take(j).ToList();
                    if (range.Sum() == invalidNumber)
                        return range;
                }
            }
            throw new Exception("No range found.");
        }

        private static List<long> GetRangeV2(long invalidNumber, List<long> numbers)
        {
            int i = 0; 
            int j = 2;
            var sum = numbers[0] + numbers[1];
            while (j < numbers.Count - i)
            {
                while (sum < invalidNumber) 
                {
                    sum += numbers[i + j];
                    j++;
                }
                while(sum > invalidNumber)
                {
                    sum -= numbers[i++];
                    --j;
                }
                if (sum == invalidNumber)
                    return numbers.Skip(i).Take(j).ToList();
            }
            throw new Exception("No range found.");
        }

        public static List<long> GetNumbers()
        {
            return strings.Select(s => long.Parse(s)).ToList();
        }

        private static List<long> GetPairSums(List<long> numbers)
        {
            List<long> nums = new List<long>(numbers.Count * numbers.Count);
            for(int i = 0; i < numbers.Count - 1; i++)
            {
                nums.AddRange(numbers.Skip(i+1).Select(n => n + numbers[i]));
            }
            return nums;
        }
    }
}
