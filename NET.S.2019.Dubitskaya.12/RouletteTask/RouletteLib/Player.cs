using System;

namespace RouletteLib
{
    /// <summary>
    /// Represents player abstraction and provides it's methods
    /// </summary>
    public class Player : IPlayer
    {
        private int _currNum;
        private string _name;

        /// <summary>
        /// Initializes a new instance of the Player class.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>instance</returns>
        public Player(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Signes the player for the event, when black wins
        /// </summary>
        /// <param name="roulette"></param>
        public void BetOnBlack(Roulette roulette)
        {
            if (roulette == null)
                throw new ArgumentNullException();

            roulette.BlackWins += BetMethod;
            roulette.RedWins -= BetMethod;
        }

        /// <summary>
        /// Signes the player for the event, when red wins
        /// </summary>
        /// <param name="roulette"></param>
        public void BetOnRed(Roulette roulette)
        {
            if (roulette == null)
                throw new ArgumentNullException();

            roulette.RedWins += BetMethod;
            roulette.BlackWins -= BetMethod;
        }

        /// <summary>
        /// Signes the player for the event, when even wins
        /// </summary>
        /// <param name="roulette"></param>
        public void BetOnEven(Roulette roulette)
        {
            if (roulette == null)
                throw new ArgumentNullException();

            roulette.EvenWins += BetMethod;
            roulette.OddWins -= BetMethod;
        }

        /// <summary>
        /// Signes the player for the event, when black wins
        /// </summary>
        /// <param name="roulette"></param>
        public void BetOnOdd(Roulette roulette)
        {
            if (roulette == null)
                throw new ArgumentNullException();

            roulette.OddWins += BetMethod;
            roulette.EvenWins -= BetMethod;
        }

        /// <summary>
        /// Signes the player for the event, when any number wins and saves player bet number
        /// </summary>
        /// <param name="roulette"></param>
        /// <param name="num"></param>
        public void BetOnNum(Roulette roulette, int num)
        {
            if (roulette == null)
                throw new ArgumentNullException();

            if (num < 1 || num > 36)
                throw new ArgumentException("You can bet only on numbers from 1 to 36");

            _currNum = num;
            roulette.SomeNumWins += BetMethod;
        }

        /// <summary>
        /// Unsignes player from all the event
        /// </summary>
        /// <param name="roulette"></param>
        public void RemoveBets(Roulette roulette)
        {
            roulette.SomeNumWins -= BetMethod;
            roulette.OddWins -= BetMethod;
            roulette.EvenWins -= BetMethod;
            roulette.RedWins -= BetMethod;
            roulette.BlackWins -= BetMethod;
        }

        /// <summary>
        /// Method, that invokes when any of the player's bets wins if he bet on color or parity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BetMethod(object sender, EventArgs e)
        {
            Console.WriteLine("\t{0}, you won", _name);
        }

        /// <summary>
        /// Method, that invokes if player bet on any number, displays if his bet won
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BetMethod(object sender, RouletteSpinsEventArgs e)
        {
            if (_currNum == e.WinningNum)
            {
                Console.WriteLine("\t{0}, you won", _name);
            }
        }        
    }
}
