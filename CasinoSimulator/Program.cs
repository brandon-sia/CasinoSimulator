using System;

namespace CasinoSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = 0.75;

            Guy player = new Guy() { Name = "The player", Cash = 100};

            while(player.Cash > 0)
            {
                Console.WriteLine("Welcome to the casino. The odds are " + odds);

                Console.WriteLine("The player has " + player.Cash + " bucks.");
                Console.Write("How much would you like to bet: ");
                string howMuch = Console.ReadLine();
                bool isValid = int.TryParse(howMuch, out int amount);

                if (isValid)
                {
                    int pot = player.GiveCash(amount) * 2;

                    if (pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            int winnings = pot;
                            Console.WriteLine("You win " + winnings);
                            player.ReceiveCash(winnings);
                        }
                        else
                        {
                            Console.WriteLine("Bad luck, you lose.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");

                }
            }

            Console.WriteLine("The house always wins.");



        }
    }
}
