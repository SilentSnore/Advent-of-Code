using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string hugeText = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\in.txt");
            //string hugeText = "a ab abc abd abf abj";
            int br = 0;


            
            string[] lines = hugeText.Split('\n');
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                //linija nije validna ako bilo koje dvije rijeci nisu validne. Dakle ako check vrati false, te dvije rijeci nisu validne pa time i linija nije validna

                bool lineIsNotValid = false;
                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i].Trim();
                    for (int j = 0; j < words.Length; j++)
                    {
                        if (i == j)
                            continue;
                        string other = words[j].Trim();
                        if (!check(word, other))
                        {
                            lineIsNotValid = true;
                            break;
                        }
                    }
                    if (lineIsNotValid)
                        break;
                }
                if (lineIsNotValid)
                    continue;
                br++;
            }

            Console.WriteLine(br);
            

            //Console.WriteLine(check("ab", "a"));

            Console.ReadKey();
        }

        //vraca true ako su rijeci validne, false nisu validne (validne rijeci su npr. {abcde, fghij}, a NE validne npr. {abcde, ecdab})
        public static bool check(string a, string b)
        {
            char[] fl = a.Trim().ToCharArray();
            char[] sl = b.Trim().ToCharArray();

            if (fl.Length != sl.Length)
                return true;

            for (int i = 0; i < fl.Length; i++)
            {
                for (int j = 0; j < sl.Length; j++)
                {
                    if (fl[i].Equals(sl[j]))
                    {
                        sl[j] = '#';
                        break;
                    }
                }
            }

            bool valid = false;
            foreach (char c in sl)
            {
                if (!c.Equals('#'))
                {
                    valid = true;
                }
            }
            return valid;
        }
    }
}
