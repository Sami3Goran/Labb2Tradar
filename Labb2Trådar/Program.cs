using System.Threading;

namespace Labb2Trådar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"-* Skriv ""status"" sen tryck Enter för att se tävlingens status *- ");

            // detta kommer skapa en lista av bilar
            List<Car> cars = new List<Car>
            {
                new Car("Lamborghini"),
                new Car("Bugatti"),
                new Car("Mclaren"),
                new Car("Ferrari")
            };

            // en Thread för varje bil
            List<Thread> threads = new List<Thread>();
            foreach (var car in cars)
            {
                Thread thread = new Thread(car.Drive);
                threads.Add(thread);
            }

            // tävlingen startas
            Console.WriteLine("RACE START!!!");
            foreach (var thread in threads)
            {
                thread.Start();
            }

            // körs tills alla bilar har kommit i mål
            while (cars.Exists(car => !car.Finished))
            {
                // gör så att man kan kolla statusen på racet
                if (Console.KeyAvailable)
                {
                    string input = Console.ReadLine();
                    if (input.ToLower() == "status")
                    {
                        foreach (var car in cars)
                        {
                            car.PrintStatus();
                        }
                    }
                }

                // för att undvika hög CPU-använding så får tråden slumra till lite hehe
                Thread.Sleep(100);
            }

            // programmets avslutas när alla bilar har nåt mål linjen
            Console.WriteLine("RACE OVER!!!!");
        }
    }
}
