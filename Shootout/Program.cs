using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shootout
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("COWBOY SHOOTOUT -");
            Console.WriteLine("YOU ARE BACK TO BACK");
            Console.WriteLine("TAKE 10 PACES");

            for(int step = 1; step < 11; step++)
            {
                Console.Write(step.ToString() + "..");
                Thread.Sleep(500);
            }
            Console.WriteLine();
            
            Thread.Sleep(new Random().Next(100, 1000));

            if (Console.KeyAvailable)
            {
                Console.Write("HE DRAWS.....");
                // Cheated
                YouDie();
            }
            else
            {
                Console.Write("HE DRAWS.....");
                Thread.Sleep(500);
                if(Console.KeyAvailable)
                {
                    CPUDies();
                }
                else
                {
                    YouDie();
                }
            }

            Console.ReadKey(true);
        }

        static void YouDie()
        {
            Console.WriteLine("AND SHOOTS.");
            Console.WriteLine("YOU ARE DEAD.");
        }

        static void CPUDies()
        {
            Console.WriteLine("BUT YOU SHOOT FIRST.");
            Console.WriteLine("YOU KILLED HIM.");
        }
    }
}
