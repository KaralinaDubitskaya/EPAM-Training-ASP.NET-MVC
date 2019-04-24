using System;

namespace RouletteLib
{
    public class Roulette
    {
        private static Random rand = new Random();
        public event EventHandler<RouletteSpinsEventArgs> SomeNumWins;
        public event EventHandler RedWins;
        public event EventHandler BlackWins;
        public event EventHandler EvenWins;
        public event EventHandler OddWins;

        private enum Color
        {
            Red,
            Black
        }

        /// <summary>
        /// Invokes different methods depending on the random
        /// </summary>
        public void Spin()
        {
            Array values = Enum.GetValues(typeof(Color));
            Color randomColor = (Color)values.GetValue(rand.Next(values.Length));
            int winningNum = rand.Next(1, 37);

            if (randomColor == Color.Red)
                OnRedWins(new EventArgs());
            else
                OnBlackWins(new EventArgs());

            if (winningNum % 2 == 0)
                OnEvenWins(new EventArgs());
            else
                OnOddWins(new EventArgs());

            OnSomeNumWins(new RouletteSpinsEventArgs(winningNum));
        }

        /// <summary>
        /// Invokes method
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRedWins(EventArgs e)
        {
            Console.WriteLine("RED WINS");
            if (RedWins != null)
            {
                Console.WriteLine("\tWinners:");
                RedWins.Invoke(this, e);
            }

            Console.WriteLine("_______");
        }

        /// <summary>
        /// Invokes method
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnBlackWins(EventArgs e)
        {
            Console.WriteLine("BLACK WINS");
            if (BlackWins != null)
            {
                Console.WriteLine("\tWinners:");
                BlackWins.Invoke(this, e);
            }

            Console.WriteLine("_______");
        }

        /// <summary>
        /// Invokes method
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnOddWins(EventArgs e)
        {
            Console.WriteLine("ODD WINS");
            if (OddWins != null)
            {
                Console.WriteLine("\tWinners:");
                OddWins.Invoke(this, e);
            }

            Console.WriteLine("_______");
        }

        /// <summary>
        /// Invokes method
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEvenWins(EventArgs e)
        {
            Console.WriteLine("EVEN WINS");
            if (EvenWins != null)
            {
                Console.WriteLine("\tWinners:");
                EvenWins.Invoke(this, e);
            }

            Console.WriteLine("_______");
        }

        /// <summary>
        /// Invokes method
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSomeNumWins(RouletteSpinsEventArgs e)
        {
            Console.WriteLine("{0} WINS", e.WinningNum);
            SomeNumWins?.Invoke(this, e);
            Console.WriteLine("_______");
        }
    }
}
