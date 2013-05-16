namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    public class King : Figure
    {
        public King(char name)
            : base(name)
        {
        }

        /// <summary>
        /// Determines if the King can move to a given new position
        /// </summary>
        /// <param name="from">Current position of the King</param>
        /// <param name="to">The new position which the King will move to</param>
        /// <param name="attacksDownToUp"></param>
        /// <returns>Returns true if the King can move to the given new position. Otherwise, returns false.</returns>
        public override bool CanMove(Vector from, Vector to, bool attacksDownToUp = true)
        {
            if ((from.X + 1 == to.X || from.X - 1 == to.X) &&
                (from.Y + 1 == to.Y || from.Y - 1 == to.Y))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines which are the possible positions of the King object for moving up and down
        /// </summary>
        /// <param name="initialPosition">Current position of the King</param>
        /// <returns>Returns a list of possible positions of the King object for moving up and down</returns>
        public override List<Vector> GetPossibleNewPositions(Vector initialPosition, bool attacksDownToUp = true)
        {
            List<Vector> possiblePositions = new List<Vector>();

            possiblePositions.Add(new Vector(initialPosition.X + 1, initialPosition.Y + 1));
            possiblePositions.Add(new Vector(initialPosition.X + 1, initialPosition.Y - 1));
            possiblePositions.Add(new Vector(initialPosition.X - 1, initialPosition.Y + 1));
            possiblePositions.Add(new Vector(initialPosition.X - 1, initialPosition.Y - 1));

            return possiblePositions;
        }
    }
}
