using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 325489;
            int a = (int) Math.Ceiling(Math.Sqrt(n));
            if (a % 2 == 0)
                a++;
            int p = a * a - 2 * a - 2 * (a - 2) + 1;
            int d = (a - 1) / 2;
            int l;
            if (n >= p && n <= p + (a - 2))
                l = p;
            else if (n >= p + (a - 2) + 1 && n <= p + 2 * (a - 2) + 1)
                l = p + (a - 2) + 1;
            else if (n >= p + 2 * (a - 2) + 2 && n <= p + 3 * (a - 2) + 2)
                l = p + 2 * (a - 2) + 2;
            else
                l = p + 3 * (a - 2) + 3;
            
            int u = Math.Abs(n - (l + d - 1));
            int uu = (int) Math.Ceiling((decimal) a / 2);

            int udaljenost = u + uu - 1;
            Console.WriteLine(udaljenost);



            Console.ReadKey();
        }
    }
}
