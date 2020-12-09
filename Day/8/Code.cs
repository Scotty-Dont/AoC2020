using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day.Eight
{
    public static class Code
    {
        static string[] strings = System.IO.File.ReadAllLines("./Day/8/input.txt");

        public static int Answer1()
        {
            var code = GetCode();

            HashSet<int> usedInstructions = new HashSet<int>();

            int acc = 0;
            int ip = 0;
            int prevAcc = 0;

            while (!usedInstructions.Contains(ip))
            {
                usedInstructions.Add(ip);
                (prevAcc, acc, ip) = code[ip].Run(acc, ip);
            }

            return prevAcc;
        }

        public static int Answer2()
        {
            var lastindex = 0;

            int ip = 0;
            int acc = 0;
            int prevAcc = 0;
            var code = GetCode().Select((i, idx) => (i, idx)).ToList();
            do
            {
                code = GetCode().Select((i, idx) => (i, idx)).ToList();
                ip = 0;
                acc = 0;
                prevAcc = 0;    

                var possibleOp = code.Take(code.Count - lastindex).LastOrDefault(t => t.i._op == "jmp" || t.i._op == "nop");
                possibleOp.i._op = possibleOp.i._op == "nop" ? "jmp" : "nop";

                HashSet<int> usedInstructions = new HashSet<int>();

                while (ip < code.Count && !usedInstructions.Contains(ip))
                {
                    usedInstructions.Add(ip);
                    (prevAcc, acc, ip) = code[ip].i.Run(acc, ip);
                }

                lastindex = code.Count - possibleOp.idx;
            } while (ip < code.Count);
            return acc;
        }

        private static List<Instruction> GetCode()
        {
            return strings.Select(s => new Instruction(s)).ToList();
        }
    }

    public class Instruction
    {
        public string _op;
        public readonly int _val;

        public Instruction(string instruction)
        {
            var opAndVal = instruction.Split(' ');
            _op = opAndVal[0];
            _val = int.Parse(opAndVal[1]);
        }

        public (int previousAcc, int acc, int ip) Run(int acc, int ip)
        {
            switch (_op)
            {
                case "jmp":
                    return (acc, acc, ip + _val);
                case "nop":
                    return (acc, acc, ip + 1);
                case "acc":
                    return (acc, acc + _val, ip + 1);
                default:
                    throw new ArgumentException($"Invalid OpCode {_op} at {ip}");
            }
        }
    }
}
