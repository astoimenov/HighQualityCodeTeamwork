// <copyright file="Board.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Represents the board of the game. Responsible for adding and moving figures on the board.
    /// </summary>
    public class Board
    {
        private Figure[,] board;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="width">The width of the board</param>
        /// <param name="height">The height of the board.</param>
        public Board(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("The borad must have positive width and height.");
            }

            this.board = new Figure[width, height];
        }

        /// <summary>
        /// Gets the width of the board.
        /// </summary>
        public int Width
        {
            get
            {
                return this.board.GetLength(0);
            }
        }

        /// <summary>
        /// Gets the height of the board.
        /// </summary>
        public int Height
        {
            get
            {
                return this.board.GetLength(1);
            }
        }

        /// <summary>
        /// Gets the figure on a given position.
        /// </summary>
        /// <param name="x">The X coordinate of the position.</param>
        /// <param name="y">The Y coordinate of the position.</param>
        /// <returns>The figure object on the given position, or null if there is no figure on this position.</returns>
        public Figure this[int x, int y]
        {
            get
            {
                return this.board[x, y];
            }
        }

        /// <summary>
        /// Adds a figure to the board.
        /// </summary>
        /// <param name="figure">The figure to be added.</param>
        /// <param name="position">The position on which the figure to be added.</param>
        public void AddFigure(Figure figure, Vector position)
        {
            if (!this.Exists(position))
            {
                throw new InvalidPositionException(position, "The position doesn't exists.");
            }

            if (!this.IsEmpty(position))
            {
                throw new InvalidPositionException(position, "The position is not empty.");
            }

            this.board[position.X, position.Y] = figure;
        }

        /// <summary>
        /// Moves a figure from one position to other.
        /// </summary>
        /// <param name="oldPosition">The position from which to move a figure.</param>
        /// <param name="newPosition">The new position of the figure.</param>
        public void MoveFigure(Vector oldPosition, Vector newPosition)
        {
            if (!this.Exists(oldPosition))
            {
                throw new InvalidPositionException(oldPosition, "The position doesn't exists.");
            }

            if (this.IsEmpty(oldPosition))
            {
                throw new InvalidPositionException(oldPosition, "The old position must not be empty.");
            }

            if (!this.Exists(newPosition))
            {
                throw new InvalidPositionException(newPosition, "The position doesn't exists.");
            }

            if (!this.IsEmpty(newPosition))
            {
                throw new InvalidPositionException(newPosition, "The position is not empty.");
            }

            // Changing the position of the figure
            this.board[newPosition.X, newPosition.Y] = this.board[oldPosition.X, oldPosition.Y];
            this.board[oldPosition.X, oldPosition.Y] = null;
        }

        /// <summary>
        /// Checks if a given position exists and is emppty.
        /// </summary>
        /// <param name="position">The position to be checked.</param>
        /// <returns>True - if the position exists and is empty, or false - otherwise.</returns>
        public bool IsEmptyPosition(Vector position)
        {
            bool result = this.Exists(position) && this.IsEmpty(position);
            return result;
        }

        /// <summary>
        /// Gets the content of the board as a char matrix.
        /// </summary>
        /// <returns>The char matrix representation of the field.</returns>
        public char[,] GetContent()
        {
            char[,] result = new char[this.Height, this.Width];
            for (int col = 0; col < this.Width; col++)
            {
                for (int row = 0; row < this.Height; row++)
                {
                    if (this[col, row] != null)
                    {
                        result[row, col] = this.board[col, row].Name;
                    }
                }
            }

            return result;
        }

        private bool Exists(Vector position)
        {
            if (position.X >= 0 && position.X < this.Width &&
                position.Y >= 0 && position.Y < this.Height)
            {
                return true;
            }

            return false;
        }

        private bool IsEmpty(Vector position)
        {
            Debug.Assert(this.Exists(position), "The position doesn't exists.");

            if (this.board[position.X, position.Y] == null)
            {
                return true;
            }

            return false;
        }
    }
}
