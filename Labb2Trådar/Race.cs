using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Trådar
{
    internal class Race
    {
        private static object lockObject = new object();
        private static bool winnerDeclared = false;
        private static Car winner;

        public static bool WinnerDeclared
        {
            get { return winnerDeclared; }
        }

        public static void DeclareWinner(Car car)
        {
            lock (lockObject)
            {
                if (!winnerDeclared)
                {
                    winner = car;
                    winnerDeclared = true;
                    Console.WriteLine($"{car.name} Is the race winner of the year!");
                }
            }
        }
    }
}
