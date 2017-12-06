using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Program
    {
        private static readonly List<List<int>> Reg = new List<List<int>>();
        static void Main(string[] args)
        {
            string input = "11\t11\t13\t7\t0\t15\t5\t5\t4\t4\t1\t1\t7\t1\t15\t11";
            string[] blocks = input.Split('\t');
            List<int> memory = blocks.Select(block => Int32.Parse(block)).ToList();


            int steps = 0;
            bool infiniteLoopDetected = false;
            while (!infiniteLoopDetected)
            {
                steps++;
                int max = Int32.MinValue;
                int positionOfMax = Int32.MinValue;
                for (int i = 0; i < memory.Count; i++)
                {
                    if (memory[i] > max)
                    {
                        max = memory[i];
                        positionOfMax = i;
                    }
                }

                int currentPosition = Next(memory, positionOfMax);
                memory[positionOfMax] = 0;
                while (max > 0)
                {
                    max--;
                    memory[currentPosition]++;
                    currentPosition = Next(memory, currentPosition);
                }
                if (CheckConfiguration(new List<int>(memory)))
                    infiniteLoopDetected = true;
            }

            Console.WriteLine(steps);
            Console.WriteLine(steps - Reg.FindIndex(list => list.SequenceEqual(memory) && list.Count == memory.Count) - 1);
            Console.ReadKey();
        }

        private static bool CheckConfiguration(List<int> memory)
        {
            if (Reg.Any(list => list.SequenceEqual(memory) && list.Count == memory.Count))
                return true;
            Reg.Add(memory);
            return false;
        }

        private static int Next(List<int> memory, int currentPostion)
        {
            if (currentPostion == memory.Count - 1)
                return 0;
            return currentPostion + 1;
        }
    }
}
