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

        public override bool CanMove(Vector from, Vector to, bool attacksDownToUp = true)
        {
            if ((from.X + 1 == to.X || from.X - 1 == to.X) &&
                (from.Y + 1 == to.Y || from.Y - 1 == to.Y))
            {
                return true;
            }

            return false;
        }

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
