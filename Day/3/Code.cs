using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day.Three
{
    public static class Code
    {
        static string[] strings = System.IO.File.ReadAllLines("./Day/3/input.txt");

        internal enum Grid
        {
            Tree,
            Empty
        }
        public static int Answer1()
        {
            int right = 3, down = 1;
            return GetTreesBySlope(strings, right, down);
        }

        public static long Answer2()
        {
            var slopes = new[] {
                (right: 1, down: 1),
                (right: 3, down: 1),
                (right: 5, down: 1),
                (right: 7, down: 1),
                (right: 1, down: 2)
            };
            var slopeTrees = slopes.Select(s => (long)GetTreesBySlope(strings, s.right, s.down)).ToArray();
            return slopeTrees.Aggregate(1L, (v, s) => s * v);
        }

        private static int GetTreesBySlope(string[] strings, int right, int down)
        {
            var grid = strings.Select(s => s.Select(c => c == '.' ? Grid.Empty : Grid.Tree).ToArray()).ToArray();

            int gridWidth = grid.First().Length;

            int x = 0, y = 0;


            var trees = 0;
            while (y < grid.GetLength(0))
            {
                if (grid[y][x % gridWidth] == Grid.Tree)
                    ++trees;
                y += down;
                x += right;
            }

            return trees;
        }
    }
}
