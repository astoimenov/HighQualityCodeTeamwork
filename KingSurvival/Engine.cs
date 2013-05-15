// <copyright file="Engine.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the main logic of the game. Responsible for keeping the rules and makes decisions what
    /// should happen after every step of the game. It is a kind of facade design pattern.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// True if the king attacks to the up side of the board.
        /// </summary>
        public const bool KingAttacksToUp = true;

        /// <summary>
        /// The board in which the current game is played.
        /// </summary>
        private Board board;

        /// <summary>
        /// Responsible for rendering the game UI to the user. 
        /// </summary>
        private IRenderer renderer;

        /// <summary>
        /// Responsible for collecting the user commands and passing them to the engine of the game.
        /// </summary>
        private IUserInterface userInterface;

        /// <summary>
        /// Represents the current state of the game (composed by the most important information of the game).
        /// </summary>
        private GameState state;

        /// <summary>
        /// The current coordinates of the <see cref="King"/> figure on the board.
        /// </summary>
        private Vector kingsCoordinates;

        /// <summary>
        /// Collection of all the figures on the board.
        /// </summary>
        private Dictionary<char, Vector> figures;

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine"/> class.
        /// </summary>
        public Engine()
        {
            this.Initialize();
            this.AddAllFigures();
        }

        /// <summary>
        /// Triggered when the game is finished no matter who is the winner.
        /// </summary>
        public event GameOverEventHandler GameOver;

        /// <summary>
        /// Start the game (the game loop).
        /// </summary>
        public void Start()
        {
            this.renderer.Render(this.state);
            this.userInterface.CommandArrived += this.CommandArrivedHandler;

            while (this.state.IsKingWinner == null)
            {
                this.userInterface.ListenForCommand(this.state.IsKingsTurn);
            }
        }

        /// <summary>
        /// Initializes all the needed components of the game (board, renderer etc.).
        /// </summary>
        private void Initialize()
        {
            this.board = new Board(8, 8);
            this.renderer = new ConsoleRenderer();
            this.userInterface = new ConsoleUserInterface();
            this.state = new GameState(this.board, 0, true, null);
            this.figures = new Dictionary<char, Vector>();
        }

        /// <summary>
        /// Adds all the needed figures on the board including the <see cref="King"/> figure.
        /// </summary>
        private void AddAllFigures()
        {
            this.kingsCoordinates = new Vector(3, 7);
            this.AddFigure(new King('K'), this.kingsCoordinates);
            this.AddFigure(new Pawn('A'), new Vector(0, 0));
            this.AddFigure(new Pawn('B'), new Vector(2, 0));
            this.AddFigure(new Pawn('C'), new Vector(4, 0));
            this.AddFigure(new Pawn('D'), new Vector(6, 0));
        }

        /// <summary>
        /// Adds a single figure to a given position on the board.
        /// </summary>
        /// <param name="figure">The figure to be added.</param>
        /// <param name="position">The position which to be added the figure on.</param>
        /// <exception cref="DuplicationException">If on the board exists a figure with the same name as <paramref name="figure"/>'s name.</exception>
        /// <exception cref="InvalidPositionException">If the <paramref name="position"/> doesn't exists or is already occupied.</exception>
        private void AddFigure(Figure figure, Vector position)
        {
            if (this.figures.ContainsKey(figure.Name))
            {
                string message = string.Format("There is already a figure with name {0} on the board.", figure.Name);
                throw new DuplicationException<Figure>(figure, message);
            }

            if (!this.board.IsEmptyPosition(position))
            {
                throw new InvalidPositionException(position, "The position doesn't exists or is already occupied");
            }

            this.board.AddFigure(figure, position);
            this.figures.Add(figure.Name, position);
        }

        /// <summary>
        /// Moves an already existing figure to a new position on the board.
        /// </summary>
        /// <param name="name">The name of the figure to be moved.</param>
        /// <param name="newPosition">The new position of the figure.</param>
        /// <exception cref="InvalidMovementException">The figure can't be moved because the rules of the game doesn't allow it.</exception>
        private void MoveFigure(char name, Vector newPosition)
        {
            if (!this.figures.ContainsKey(name))
            {
                throw new InvalidMovementException(string.Format("There is no figure with name {0} on the board.", name));
            }

            Vector oldPosition = this.figures[name];
            Figure figure = this.board[oldPosition.X, oldPosition.Y];
            bool isTheKing = this.kingsCoordinates.Equals(oldPosition);

            if (isTheKing != this.state.IsKingsTurn)
            {
                throw new InvalidMovementException("The figure can't be moved. It is not it's turn.");
            }

            if (isTheKing && !figure.CanMove(oldPosition, newPosition))
            {
                throw new InvalidMovementException("The figure can't be moved. It can't perform this type of movement.");
            }

            if (!isTheKing && !figure.CanMove(oldPosition, newPosition, false))
            {
                throw new InvalidMovementException("The figure can't be moved. It can't perform this type of movement.");
            }

            try
            {
                this.board.MoveFigure(oldPosition, newPosition);
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

        /// <summary>
        /// An event handler which implements the logic after a new command has arrived from the user.
        /// Triggers the <see cref="Engine.GameOver"/> event if the game is over.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="eventArguments">Information about the event containing the command arrived.</param>
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

            switch (char.ToUpper(command[1]))
            {
                case 'U':
                    newYValue = currentPosition.Y - 1;
                    break;
                case 'D':
                    newYValue = currentPosition.Y + 1;
                    break;
                default:
                    this.renderer.RenderInvalidCommand();
                    return;
            }

            switch (char.ToUpper(command[2]))
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
                this.GameOver(this, new GameOverEventArgs(this.state));
            }
        }

        /// <summary>
        /// Checks if the game should be finished in the current moment.
        /// </summary>
        /// <returns>True if the game should be finished, false - if not.</returns>
        private bool CheckForGameOver()
        {
            if (this.state.IsKingsTurn)
            {
                if (!this.CanKingMove())
                {
                    this.state.IsKingWinner = false;
                    return true;
                }
            }
            else if (this.IsKingOnLastLine() || !this.CanOppositeFiguresMove())
            {
                this.state.IsKingWinner = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the king figure has a valid moves.
        /// </summary>
        /// <returns>True if the king can move, false - if not.</returns>
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

        /// <summary>
        /// Checks if the opposite (of the King's team) team' figures has a valid moves.
        /// </summary>
        /// <returns>True - if the figures can move, false - otherwise.</returns>
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

        /// <summary>
        /// Checks if the kings figure has reached the last line.
        /// </summary>
        /// <returns>True if the king is on the last line, false - otherwise.</returns>
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
