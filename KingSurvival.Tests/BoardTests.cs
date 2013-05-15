namespace KingSurvival.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BoardTests
    {
        public bool MatrixEquals(char[,] matrix1, char[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) ||
                matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                return false;
            }

            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                for (int col = 0; col < matrix1.GetLength(1); col++)
                {
                    if (matrix1[row, col] != matrix2[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BoardCreationWithNonPositiveDimensions()
        {
            Board board = new Board(0, 4);
        }

        [TestMethod]
        public void BoardSimpleMovement()
        {
            Board board = new Board(3, 3);
            board.AddFigure(new King('K'), new Vector(0, 0));
            board.AddFigure(new Pawn('A'), new Vector(0, 1));

            board.MoveFigure(new Vector(0, 0), new Vector(2, 2));
            board.MoveFigure(new Vector(0, 1), new Vector(1, 0));

            char[,] actual = board.GetContent();
            char[,] expected = 
            {
                {'\0', 'A', '\0'},
                {'\0', '\0', '\0'},
                {'\0', '\0', 'K'},
            };

            Assert.IsTrue(this.MatrixEquals(expected, actual));
        }

        [TestMethod]
        public void BoardCyclicMovement()
        {
            Board board = new Board(3, 3);
            board.AddFigure(new King('K'), new Vector(0, 0));

            board.MoveFigure(new Vector(0, 0), new Vector(2, 2));
            board.MoveFigure(new Vector(2, 2), new Vector(0, 0));
            board.MoveFigure(new Vector(0, 0), new Vector(2, 2));
            board.MoveFigure(new Vector(2, 2), new Vector(0, 0));
            board.MoveFigure(new Vector(0, 0), new Vector(2, 2));

            char[,] actual = board.GetContent();
            char[,] expected = 
            {
                {'\0', '\0', '\0'},
                {'\0', '\0', '\0'},
                {'\0', '\0', 'K'},
            };

            Assert.IsTrue(this.MatrixEquals(expected, actual));
        }

        [TestMethod]
        public void BoardAsimetric()
        {
            Board board = new Board(6, 3);
            board.AddFigure(new King('K'), new Vector(5, 2));
            board.AddFigure(new Pawn('A'), new Vector(5, 1));

            board.MoveFigure(new Vector(5, 2), new Vector(0, 2));
            board.MoveFigure(new Vector(5, 1), new Vector(0, 1));

            char[,] actual = board.GetContent();
            char[,] expected = 
            {
                {'\0', '\0', '\0', '\0', '\0', '\0'},
                {'A', '\0', '\0', '\0', '\0', '\0'},
                {'K', '\0', '\0', '\0', '\0', '\0'},
            };

            Assert.IsTrue(this.MatrixEquals(expected, actual));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void BoardAdditionOnNonExistingPosition()
        {
            Board board = new Board(6, 3);
            board.AddFigure(new King('K'), new Vector(6, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void BoardAdditionOnOccupiedPosition()
        {
            Board board = new Board(6, 3);
            board.AddFigure(new King('K'), new Vector(5, 2));
            board.AddFigure(new Pawn('A'), new Vector(5, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void BoardMoveFigureEmptyOldPosition()
        {
            Board board = new Board(6, 3);
            board.AddFigure(new King('K'), new Vector(5, 2));
            board.MoveFigure(new Vector(1, 1), new Vector(2, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void BoardMoveFigureNonExistingOldPosition()
        {
            Board board = new Board(6, 3);
            board.AddFigure(new King('K'), new Vector(5, 2));
            board.MoveFigure(new Vector(3, 3), new Vector(2, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void BoardMoveFigureOccupiedNewPosition()
        {
            Board board = new Board(6, 3);
            board.AddFigure(new King('K'), new Vector(5, 2));
            board.AddFigure(new Pawn('K'), new Vector(1, 1));
            board.MoveFigure(new Vector(5, 2), new Vector(1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        public void BoardMoveFigureNonExistingNewPosition()
        {
            Board board = new Board(6, 3);
            board.AddFigure(new King('K'), new Vector(5, 2));
            board.MoveFigure(new Vector(5, 2), new Vector(5, 3));
        }

        [TestMethod]
        public void BoardIsEmptyPositionTrue()
        {
            Board board = new Board(6, 3);
            board.AddFigure(new King('K'), new Vector(5, 2));
            bool actual = board.IsEmptyPosition(new Vector(5, 1));

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void BoardIsEmptyOccupiedPosition()
        {
            Board board = new Board(6, 3);
            board.AddFigure(new King('K'), new Vector(5, 2));
            bool actual = board.IsEmptyPosition(new Vector(5, 2));

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void BoardIsEmptyNonExistingPosition()
        {
            Board board = new Board(6, 3);
            board.AddFigure(new King('K'), new Vector(5, 2));
            bool actual = board.IsEmptyPosition(new Vector(5, 3));

            Assert.IsFalse(actual);
        }
    }
}
