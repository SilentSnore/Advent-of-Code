using System;
using System.Text.RegularExpressions;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            string hugeLine = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\in.txt");
            hugeLine = Regex.Replace(hugeLine, "!.", "");
            int numAfterFilter = hugeLine.Length;
            hugeLine = Regex.Replace(hugeLine, "<.*?>", "<>");
            int numAfterGarbageRemoved = hugeLine.Length;
            hugeLine = Regex.Replace(hugeLine, "<>", "");
            int total = 0, score = 0;
            foreach (char c in hugeLine.ToCharArray())
            {
                if (c.Equals('{'))
                    score++;
                else if (c.Equals('}'))
                {
                    total += score;
                    score--;
                }
            }
            Console.WriteLine(total);
            Console.WriteLine(numAfterFilter - numAfterGarbageRemoved);
            //System.IO.File.WriteAllText(@"C:\Users\Naga\Desktop\out.txt", hugeLine);
            Console.ReadKey();
        }
    }
}
