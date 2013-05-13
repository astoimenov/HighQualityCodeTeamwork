using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KingSurvival
{
    public class Engine
    {
        public const bool KingAttacksToUp = true;

        private Board board;
        private IRenderer renderer;
        private IUserInterface userInterface;
        private GameState state;

        // Figures
        private Vector kingsCoordinates;
        private Dictionary<char, Vector> figures;

        public event GameOverEventHandler GameOver;

        public Engine()
        {
            this.Initialize();
            this.AddAllFigures();
        }

        public void Start()
        {
            this.renderer.Render(this.state);
            this.userInterface.CommandArrived += this.CommandArrivedHandler;

            while (this.state.IsKingWinner == null)
            {
                this.userInterface.ListenForCommand(this.state.IsKingsTurn);
            }
        }

        private void Initialize()
        {
            this.board = new Board(8, 8);
            this.renderer = new ConsoleRenderer();
            this.userInterface = new ConsoleUserInterface();
            this.state = new GameState(this.board, 0, true, null);
            this.figures = new Dictionary<char, Vector>();
        }

        private void AddAllFigures()
        {
            this.kingsCoordinates = new Vector(3, 7);
            this.AddFigure(new King('K'), this.kingsCoordinates);
            this.AddFigure(new Pawn('A'), new Vector(0, 0));
            this.AddFigure(new Pawn('B'), new Vector(2, 0));
            this.AddFigure(new Pawn('C'), new Vector(4, 0));
            this.AddFigure(new Pawn('D'), new Vector(6, 0));
        }

        private void AddFigure(Figure figure, Vector position)
        {
            if (this.figures.ContainsKey(figure.Name))
            {
                string message = String.Format("There is already a figure with name {0} on the board.", figure.Name);
                throw new DuplicationException<Figure>(figure, message);
            }

            this.board.AddFigure(figure, position);
            this.figures.Add(figure.Name, position);
        }

        private void MoveFigure(char name, Vector newPosition)
        {
            if (!this.figures.ContainsKey(name))
            {
                throw new InvalidMovementException(String.Format("There is no figure with name {0} on the board.", name));
            }

            Vector oldPosition = this.figures[name];
            Figure figure = board[oldPosition.X, oldPosition.Y];
            bool isTheKing = this.kingsCoordinates.Equals(oldPosition);

            if (isTheKing != this.state.IsKingsTurn)
            {
                throw new InvalidMovementException("The figure can't be moved. It is not it's turn.");
            }

            if (!figure.CanMove(oldPosition, newPosition))
            {
                throw new InvalidMovementException("The figure can't be moved. It can't perform this type of movement.");
            }

            try
            {
                board.MoveFigure(oldPosition, newPosition);
            }
            catch (InvalidPositionException e)
            {
                throw new InvalidMovementException("The new position of the figure is invalid.", e);
            }

            this.figures[name] = newPosition;

            if (this.state.IsKingsTurn)
            {
                this.state.KingMovesCount++;
                this.kingsCoordinates = newPosition;
            }

            this.state.IsKingsTurn = !this.state.IsKingsTurn;
            this.CheckForGameOver();
        }

        private void CommandArrivedHandler(object sender, CommandArrivedArgs eventArguments)
        {
            if (eventArguments.Command == null)
            {
                this.renderer.RenderInvalidCommand();
                return;
            }

            string command = eventArguments.Command.Trim();

            if (command.Length != 3)
            {
                this.renderer.RenderInvalidCommand();
                return;
            }

            if (!this.figures.ContainsKey(command[0]))
            {
                this.renderer.RenderInvalidCommand();
                return;
            }

            char figureName = command[0];
            Vector currentPosition = this.figures[figureName];
            int newXValue = 0;
            int newYValue = 0;

            switch (Char.ToUpper(command[1]))
            {
                case 'U' :
                    newYValue = currentPosition.Y - 1;
                    break;
                case 'D':
                    newYValue = currentPosition.Y + 1;
                    break;
                default:
                    this.renderer.RenderInvalidCommand();
                    return;
            }

            switch (Char.ToUpper(command[2]))
            {
                case 'L':
                    newXValue = currentPosition.X - 1;
                    break;
                case 'R':
                    newXValue = currentPosition.X + 1;
                    break;
                default:
                    this.renderer.RenderInvalidCommand();
                    return;
            }

            try
            {
                this.MoveFigure(figureName, new Vector(newXValue, newYValue));
            }
            catch (InvalidMovementException)
            {
                this.renderer.RenderInvalidCommand();
                return;
            }

            this.renderer.Render(this.state);

            if (this.state.IsKingWinner != null && this.GameOver != null)
            {
                GameOver(this, new GameOverEventArgs(this.state));
            }
        }

        private bool CheckForGameOver()
        {
            if (this.state.IsKingsTurn)
            {
                if (!CanKingMove())
                {
                    this.state.IsKingWinner = false;
                    return true;
                }
            }
            else if(this.IsKingOnLastLine() || !this.CanOppositeFiguresMove())
            {
                this.state.IsKingWinner = true;
                return true;
            }

            return false;
        }

        private bool CanKingMove()
        {
            Figure king = this.board[this.kingsCoordinates.X, this.kingsCoordinates.Y];
            List<Vector> possibleNextPossitions = king.GetPossibleNewPositions(this.kingsCoordinates, Engine.KingAttacksToUp);
            foreach (Vector position in possibleNextPossitions)
            {
                if (this.board.IsEmptyPosition(position))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CanOppositeFiguresMove()
        {
            foreach (var figure in this.figures)
            {
                if (!figure.Value.Equals(this.kingsCoordinates))
                {
                    Figure pawn = this.board[figure.Value.X, figure.Value.Y];
                    List<Vector> possibleNextPossitions = pawn.GetPossibleNewPositions(figure.Value, !Engine.KingAttacksToUp);

                    foreach (Vector position in possibleNextPossitions)
                    {
                        if (this.board.IsEmptyPosition(position))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool IsKingOnLastLine()
        {
            if ((Engine.KingAttacksToUp && this.kingsCoordinates.Y == 0) ||
                (!Engine.KingAttacksToUp && this.kingsCoordinates.Y == this.board.Height - 1))
            {
                return true;
            }

            return false;
        }
    }
}
