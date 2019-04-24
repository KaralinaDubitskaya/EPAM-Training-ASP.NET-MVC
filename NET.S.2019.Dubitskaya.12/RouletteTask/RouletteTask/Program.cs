using System;
using RouletteLib;

namespace RouletteTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Roulette roulette = new Roulette();
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");

            player1.BetOnRed(roulette);
            player1.BetOnEven(roulette);

            player2.BetOnRed(roulette);
            player2.BetOnNum(roulette, 26);

            roulette.Spin();
            player1.RemoveBets(roulette);
            player2.RemoveBets(roulette);
            Console.Read();
        }
    }
}
