using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string hugeText = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\in.txt");
            string[] lines = hugeText.Split('\n');
            List<int> maze = new List<int>(lines.Length);
            foreach (string line in lines)
            {
                maze.Add(Int32.Parse(line));
            }

            int steps = 0, currentPosition = 0, exit = maze.Count;
            while (currentPosition < exit)
            {
                int relativePosition = maze.ElementAt(currentPosition);
                if (relativePosition >= 3)
                    maze[currentPosition] = relativePosition - 1;
                else
                    maze[currentPosition] = relativePosition + 1;
                currentPosition += relativePosition;
                steps++;
            }
            Console.WriteLine(steps);
            Console.ReadKey();
        }
    }
}
