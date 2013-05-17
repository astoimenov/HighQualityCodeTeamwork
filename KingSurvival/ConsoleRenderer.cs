// <copyright file="ConsoleRenderer.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;
    using System.Text;

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

                    currentSymbol = this.AlternateSymbol(currentSymbol);
                }

                result.AppendLine();
            }

            if (state.IsKingWinner != null)
            {
                if (state.IsKingWinner.Value == true)
                {
                    result.AppendLine(string.Format("King wins in {0} turns.", state.KingMovesCount));
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
            Console.WriteLine("Illegal move!");
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
                case ConsoleRenderer.WhiteSymbol:
                    return ConsoleRenderer.BlackSymbol;
                case ConsoleRenderer.BlackSymbol:
                    return ConsoleRenderer.WhiteSymbol;
                default:
                    string message = string.Format(
                        "The symbol must be {0} or {1}.",
                        ConsoleRenderer.WhiteSymbol,
                        ConsoleRenderer.BlackSymbol);
                    throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}
