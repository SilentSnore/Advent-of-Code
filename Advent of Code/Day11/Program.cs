using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\example1.txt");
            //string input = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\example2.txt");
            //string input = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\example3.txt");
            //string input = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\example4.txt");
            string input = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\in.txt");

            int maxDistanceEverMade = Int32.MinValue;
            string[] directions = input.Split(',');
            int x = 0, y = 0;
            foreach (string direction in directions)
            {
                if (direction.Equals("nw"))
                {
                    x--;
                }
                else if (direction.Equals("n"))
                {
                    y++;
                }
                else if (direction.Equals("ne"))
                {
                    x++;
                    y++;
                }
                else if (direction.Equals("se"))
                {
                    x++;
                }
                else if (direction.Equals("s"))
                {
                    y--;
                }
                else
                {
                    x--;
                    y--;
                }

                int distance = GetDistance(x, y);
                if (distance > maxDistanceEverMade)
                    maxDistanceEverMade = distance;
            }
            Console.WriteLine(GetDistance(x, y));
            Console.WriteLine(maxDistanceEverMade);
            Console.ReadKey();
        }

        private static int GetDistance(int x, int y)
        {
            int h = Math.Max(Math.Abs(x), Math.Abs(y));
            return Math.Max(h, Math.Abs(x - y));
        }

    }
}
