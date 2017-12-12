using System;
using System.Collections.Generic;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\example.txt");
            string input = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\in.txt");

            string[] lines = input.Split('\n');
            List<List<int>> list = new List<List<int>>(lines.Length);
            foreach (string line in lines)
            {
                string[] lineInfo = line.Split(' ');

                List<int> subList = new List<int>(lineInfo.Length);
                for (int i = 2; i < lineInfo.Length; i++)
                {
                    subList.Add(Int32.Parse(lineInfo[i].Trim().Trim(',')));
                }
                list.Add(subList);

            }

            HashSet<int> set = new HashSet<int>();
            set.Add(0);
            int oldSize;
            do
            {
                oldSize = set.Count;
                int counter = 0;
                foreach (List<int> ints in list)
                {
                    foreach (int i in ints)
                    {
                        if (set.Contains(i))
                            set.Add(counter);
                    }
                    counter++;
                }
            } while (oldSize != set.Count);
            Console.WriteLine(set.Count);

            int numOfGroups = 1;
            HashSet<int> processed = new HashSet<int>(set);
            do
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (processed.Contains(i))
                        continue;

                    set = new HashSet<int>();
                    set.Add(i);
                    numOfGroups++;

                    do
                    {
                        oldSize = set.Count;
                        int counter = 0;
                        foreach (List<int> ints in list)
                        {
                            foreach (int j in ints)
                            {
                                if (set.Contains(j))
                                    set.Add(counter);
                            }
                            counter++;
                        }
                    } while (oldSize != set.Count);

                    foreach (int groupMember in set)
                    {
                        processed.Add(groupMember);
                    }
                }
            } while (processed.Count != list.Count);
            Console.WriteLine(numOfGroups);
            Console.ReadKey();
        }
    }
}
