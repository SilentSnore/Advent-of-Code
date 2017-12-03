using System;

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

            //drugi
            int[,] matrix = new int[503, 503];
            int number = 1;
            matrix[252, 252] = number;
            int desniRub = 252;
            int gornjiRub = 252;
            int lijeviRub = 252;
            int donjiRub = 252;
            int duljina = 1;
            int vrati = 0;
            while (true)
            {
                //pogled s desne
                for (int i = vrati; i <= duljina; i++)
                {
                    matrix[252 + i, desniRub + 1] = matrix[252 + i - 1, desniRub + 1] + matrix[252 + i - 1, desniRub] + matrix[252 + i, desniRub] + matrix[252 + i + 1, desniRub];
                    number = matrix[252 + i, desniRub + 1];
                    if (number > n)
                    {
                        Console.WriteLine(number);
                        Console.ReadKey();
                        return;
                    }
                }
                desniRub++;
                //pogled odozgo
                for (int i = vrati; i <= duljina; i++)
                {
                    matrix[gornjiRub + 1, 252 - i] = matrix[gornjiRub + 1, 252 - i + 1] + matrix[gornjiRub, 252 - i + 1] + matrix[gornjiRub, 252 - i] + matrix[gornjiRub, 252 - i - 1];
                    number = matrix[gornjiRub + 1, 252 - i];
                    if (number > n)
                    {
                        Console.WriteLine(number);
                        Console.ReadKey();
                        return;
                    }
                }
                gornjiRub++;
                //pogled s lijeve
                for (int i = vrati; i <= duljina; i++)
                {
                    matrix[252 - i, lijeviRub - 1] = matrix[252 - i + 1, lijeviRub - 1] + matrix[252 - i + 1, lijeviRub] + matrix[252 - i, lijeviRub] + matrix[252 - i - 1, lijeviRub];
                    number = matrix[252 - i, lijeviRub - 1];
                    if (number > n)
                    {
                        Console.WriteLine(number);
                        Console.ReadKey();
                        return;
                    }
                }
                lijeviRub--;
                //pogled odozdo
                for (int i = vrati; i <= duljina; i++)
                {
                    matrix[donjiRub - 1, 252 + i] = matrix[donjiRub - 1, 252 + i - 1] + matrix[donjiRub, 252 + i - 1] + matrix[donjiRub, 252 + i] + matrix[donjiRub, 252 + i + 1];
                    number = matrix[donjiRub - 1, 252 + i];
                    if (number > n)
                    {
                        Console.WriteLine(number);
                        Console.ReadKey();
                        return;
                    }
                }
                donjiRub--;
                duljina++;
                vrati--;
            }
        }
    }
}
