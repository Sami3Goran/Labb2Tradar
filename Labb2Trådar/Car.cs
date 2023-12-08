using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Labb2Trådar
{
    class Car
    {
        private static readonly Random random = new Random();
        public string name;
        public double distance;
        public double speed;
        public bool finished;

        public Car(string name)
        {
            this.name = name;
            this.distance = 0;
            this.speed = 120;
            this.finished = false;
        }

        public bool Finished
        {
            get { return finished; }
        }

        public void Drive()
        {
            Console.WriteLine($"{name} has started!");

            while (distance < 10.0)
            {
                // detta ska egentligen visa en händelse var 30e sekund, får fixa senare...
                if (random.Next(30) == 0)
                {
                    HandleEvent();
                }

                // dehär kommer få bilen/bilarna att rulla så att säga hehe
                distance += speed / 3600; // Omvandlar hastigheteb från km/h till km/s , ingen som orkar vänta för länga

                // Låt tråden sova en sekund 
                Thread.Sleep(1000);
            }

            finished = true;
            Console.WriteLine($"And {name} crosses the finish line!");
            // kollar ifall bilen nåt mål linjen 
            if (!Race.WinnerDeclared)
            {
                Race.DeclareWinner(this);
            }
        }

        // är de som visas när man skriver status, själva statusen av tävlingen
        public void PrintStatus()
        {
            Console.WriteLine($"{name} - Avstånd: {distance:F2} km, Hastighet: {speed} km/h");
        }

        private void HandleEvent()
        {
            // Meningen är att endast 1 bil ska påverkas
            if (random.Next(4) == 0) // Justeras till hur många bilar som är med i tävlingen
            {
                int eventNumber = random.Next(50);
                if (eventNumber == 0)
                {
                    Console.WriteLine($"{name} har slut på bensin och måste stanna för att tanka i 30 sekunder.");
                    Thread.Sleep(30000);
                }
                else if (eventNumber < 3)
                {
                    Console.WriteLine($"{name} har punktering och måste stanna för att byta däck i 20 sekunder.");
                    Thread.Sleep(20000);
                }
                else if (eventNumber < 8)
                {
                    Console.WriteLine($"{name} har en fågel på vindrutan och måste stanna för att tvätta rutan i 10 sekunder.");
                    Thread.Sleep(10000);
                }
                else if (eventNumber < 18)
                {
                    Console.WriteLine($"{name} har motorfel och hastigheten sänks med 1 km/h.");
                    speed--;
                }
            }
        }


    }
}
