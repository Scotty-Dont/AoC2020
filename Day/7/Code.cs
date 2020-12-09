using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day.Seven
{
    public static class Code
    {
        public static Dictionary<string, Bag> Bags = new Dictionary<string, Bag>();

        public class Bag
        {
            public Bag(string color)
            {
                Color = color;
                ContainsThis = new List<Bag>();
                ThisContains = new List<(Bag, int)>();
            }

            public override bool Equals(object obj)
            {
                return Color.Equals(((Bag)obj).Color);
            }

            public override int GetHashCode()
            {
                return Color.GetHashCode();
            }

            public string Color { get; private set; }
            public List<(Bag, int)> ThisContains { get; private set; }
            public List<Bag> ContainsThis { get; private set; }
        }

        static string[] strings = System.IO.File.ReadAllLines("./Day/7/input.txt");

        public static int Answer1()
        {
            GetBags();
            HashSet<Bag> outerBags = new HashSet<Bag>();
            var shinyGoldBag = Bags.Single(c => c.Key == "shiny gold").Value;

            List<Bag> toAdd = shinyGoldBag.ContainsThis.ToList();
            bool added = false;
            do
            {
                List<Bag> addedBag = new List<Bag>();
                added = false;
                foreach (var b in toAdd.Where(c => !outerBags.Contains(c)))
                {
                    if (outerBags.Add(b))
                    {
                        added = true;
                        addedBag.Add(b);
                    }
                }
                toAdd = new List<Bag>();
                toAdd.AddRange(addedBag.SelectMany(a => a.ContainsThis));
            } while (added);

            return outerBags.Count;
        }

        public static int Answer2()
        {
            GetBags();

            return Contains(Bags["shiny gold"], 1);
        }

        public static int Contains(Bag bag, int count)
        {
            return bag.ThisContains.Sum(b => Contains(b.Item1, b.Item2) + b.Item2) * count;
        }

        public static void GetBags()
        {
            if (Bags.Count != 0)
                return;

            foreach (var s in strings)
            {
                string[] colorAndContains = s.Split("bags contain");
                string color = colorAndContains[0].Trim();

                string[] containsList = colorAndContains[1].Split(new[] { "bags.", "bags, ", "bag, ", "bag." }, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);

                var newBag = new Bag(color);
                if (!Bags.TryAdd(color, newBag))
                {
                    newBag = Bags[color];
                }

                foreach (var containsString in containsList.Where(s => s.Trim() != "no other"))
                {
                    var bag = containsString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var count = int.Parse(bag[0]);
                    var containsColor = string.Join(' ', bag.Skip(1)).Trim();
                    Bag containsBag;
                    if (Bags.ContainsKey(containsColor))
                    {
                        containsBag = Bags[containsColor];
                    }
                    else
                    {
                        containsBag = new Bag(containsColor);
                        Bags.Add(containsColor, containsBag);
                    }
                    containsBag.ContainsThis.Add(newBag);
                    newBag.ThisContains.Add((containsBag, count));
                }
            }
        }
    }
}
