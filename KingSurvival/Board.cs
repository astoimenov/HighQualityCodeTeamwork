namespace KingSurvival
{
    using System;
    using System.Diagnostics;

    public class Board
    {
        private Figure[,] board;

        public Board(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("The borad must have positive width and height.");
            }

            this.board = new Figure[width, height];
        }

        public int Width
        {
            get
            {
                return this.board.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return this.board.GetLength(1);
            }
        }

        public Figure this[int x, int y]
        {
            get
            {
                return this.board[x, y];
            }
        }

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

        public bool IsEmptyPosition(Vector position)
        {
            bool result = this.Exists(position) && this.IsEmpty(position);
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
            Debug.Assert(this.Exists(position));

            if (this.board[position.X, position.Y] == null)
            {
                return true;
            }

            return false;
        }
    }
}
