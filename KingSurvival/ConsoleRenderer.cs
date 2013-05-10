using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public class ConsoleRenderer : IRenderer
    {
        public const char WhiteSymbol = '+';
        public const char BlackSymbol = '-';

        public void Render(GameState state)
        {
            Console.Clear();
            StringBuilder result = new StringBuilder();
            // Renders the board
            for (int i = 0; i < state.Board.Height; i++)
            {
                char currentSymbol = this.GetFirstSymbol(i);

                for (int j = 0; j < state.Board.Width; j++)
                {
                    if (state.Board[j, i] != null)
                    {
                        result.AppendFormat(" {0}", state.Board[j, i].Name);
                    }
                    else
                    {
                        result.AppendFormat(" {0}", currentSymbol);
                    }

                    currentSymbol = AlternateSymbol(currentSymbol);
                }

                result.AppendLine();
            }

            if (state.IsKingWinner != null)
            {
                if (state.IsKingWinner.Value == true)
                {
                    result.AppendLine(String.Format("King wins in {0} turns.", state.KingMovesCount));
                }
                else
                {
                    result.AppendLine("King loses.");
                }
            }

            Console.WriteLine(result);
        }

        public void RenderInvalidCommand()
        {
            Console.WriteLine("Invalid Command");
        }

        private char GetFirstSymbol(int row)
        {
            if (row % 2 == 0)
            {
                return ConsoleRenderer.WhiteSymbol;
            }

            return ConsoleRenderer.BlackSymbol;
        }

        private char AlternateSymbol(char symbol)
        {
            switch (symbol)
            {
                case ConsoleRenderer.WhiteSymbol :
                    return ConsoleRenderer.BlackSymbol;
                case ConsoleRenderer.BlackSymbol :
                    return ConsoleRenderer.WhiteSymbol;
                default :
                    string message = String.Format("The symbol must be {0} or {1}.", ConsoleRenderer.WhiteSymbol, ConsoleRenderer.BlackSymbol);
                    throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}
