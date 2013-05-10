using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public class GameOverEventArgs : EventArgs
    {
        public GameState GameState { get; private set; }

        public GameOverEventArgs(GameState gameState)
            : base()
        {
            this.GameState = gameState;
        }
    }
}
