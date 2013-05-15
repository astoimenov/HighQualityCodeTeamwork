namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    public class Pawn : Figure
    {
        public Pawn(char name)
            : base(name)
        {
        }

        public override bool CanMove(Vector from, Vector to, bool attacksDownToUp = true)
        {
            if (attacksDownToUp)
            {
                return this.CanMoveAttackingUp(from, to);
            }
            else
            {
                return this.CanMoveAttackingDown(from, to);
            }
        }

        public override List<Vector> GetPossibleNewPositions(Vector initialPosition, bool attacksDownToUp = true)
        {
            List<Vector> possiblePositions = new List<Vector>();

            if (attacksDownToUp)
            {
                possiblePositions.Add(new Vector(initialPosition.X + 1, initialPosition.Y - 1));
                possiblePositions.Add(new Vector(initialPosition.X - 1, initialPosition.Y - 1));
            }
            else
            {
                possiblePositions.Add(new Vector(initialPosition.X + 1, initialPosition.Y + 1));
                possiblePositions.Add(new Vector(initialPosition.X - 1, initialPosition.Y + 1));
            }

            return possiblePositions;
        }

        private bool CanMoveAttackingUp(Vector from, Vector to)
        {
            if ((from.X + 1 == to.X || from.X - 1 == to.X) &&
                    from.Y - 1 == to.Y)
            {
                return true;
            }

            return false;
        }

        private bool CanMoveAttackingDown(Vector from, Vector to)
        {
            if ((from.X + 1 == to.X || from.X - 1 == to.X) &&
                    from.Y + 1 == to.Y)
            {
                return true;
            }

            return false;
        }
    }
}
