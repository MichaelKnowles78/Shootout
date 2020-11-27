using System;
using System.Threading;

namespace Shootout
{
    static class Program
    {
        /// <summary>
        /// Entry point.  Initialise, play, ask to play again
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            Console.Clear();
            Console.Title = "COWBOY SHOOTOUT";

            do
            {
                GameLoop();
            } while (PlayAgain());
        }

        /// <summary>
        /// Main game loop
        /// </summary>
        private static void GameLoop()
        {
            Console.Clear();
            Console.WriteLine("YOU ARE BACK TO BACK");
            Console.WriteLine("TAKE 10 PACES");
            TakeTenPaces();

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
                if (Console.KeyAvailable)
                {
                    CPUDies();
                }
                else
                {
                    YouDie();
                }
            }

            ClearKeyPresses();
        }

        /// <summary>
        /// Counts from 1 to 10 with a gap inbetween
        /// </summary>
        private static void TakeTenPaces()
        {
            for (int step = 1; step < 11; step++)
            {
                Console.Write(step.ToString() + "..");
                Thread.Sleep(500);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Player death
        /// </summary>
        static void YouDie()
        {
            Console.WriteLine("AND SHOOTS.");
            Console.WriteLine("YOU ARE DEAD.");
        }

        /// <summary>
        /// CPU death
        /// </summary>
        static void CPUDies()
        {
            Console.WriteLine("BUT YOU SHOOT FIRST.");
            Console.WriteLine("YOU KILLED HIM.");
        }

        /// <summary>
        /// Will clear keyboard buffer to prevent too many keystrokes affecting the next shot
        /// </summary>
        static void ClearKeyPresses()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        /// <summary>        
        /// Will ask if user wants to play again and will wait until either "Y" or "N" is pressed. Can handle both upper and lower case
        /// </summary>
        /// <returns>Returns true if "Y" is pressed or false if "N" is pressed.</returns>
        private static bool PlayAgain()
        {
            Console.WriteLine("PLAY AGAIN (Y/N)");

            char keyPressed;
            do
            {
                keyPressed = Console.ReadKey(true).KeyChar;
            } while (!"yYnN".Contains(keyPressed.ToString()));

            return keyPressed == 'y' || keyPressed == 'Y';
        }
    }
}
