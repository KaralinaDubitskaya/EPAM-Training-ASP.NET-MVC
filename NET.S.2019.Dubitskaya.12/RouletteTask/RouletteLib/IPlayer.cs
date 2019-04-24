using System;

namespace RouletteLib
{
    /// <summary>
    /// Interface that defines boundaries for a new player class
    /// </summary>
    public interface IPlayer
    {
        void BetOnBlack(Roulette roulette);
        void BetOnRed(Roulette roulette);
        void BetOnEven(Roulette roulette);
        void BetOnOdd(Roulette roulette);
        void BetOnNum(Roulette roulette, int num);
        void RemoveBets(Roulette roulette);
    }
}
