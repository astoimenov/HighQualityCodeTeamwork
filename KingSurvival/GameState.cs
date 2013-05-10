using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public struct GameState
    {
        public Board Board { get; private set; }

        public uint KingMovesCount { get; set; }

        public bool IsKingsTurn { get; set; }

        public bool? IsKingWinner { get; set; }

        public GameState(Board board, uint kingMovesCount, bool isKingsTurn, bool? isKingWinner)
            : this()
        {
            if (board == null)
            {
                throw new ArgumentNullException("The board must not be null.");
            }

            this.Board = board;
            this.KingMovesCount = kingMovesCount;
            this.IsKingsTurn = isKingsTurn;
            this.IsKingWinner = isKingWinner;
        }
    }
}
