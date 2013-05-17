// <copyright file="Pawn.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a pawn.
    /// </summary>
    public class Pawn : Figure
    {
        public Pawn(char name)
            : base(name)
        {
        }

        /// <summary>
        /// Determines if the Pawn can move to a given new position
        /// </summary>
        /// <param name="from">Current position of the Pawn</param>
        /// <param name="to">The new position which the Pawn will move to</param>
        /// <param name="attacksDownToUp">True if the pawn attacks to the up direction.</param>
        /// <returns>Returns true if the Pawn can move to the given new position. Otherwise, returns false.</returns>
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

        /// <summary>
        /// Determines which are the possible positions of a Pawn object for moving up and down
        /// </summary>
        /// <param name="initialPosition">Current position of the Pawn</param>
        /// <returns>Returns a list of possible positions of a Pawn object for moving up and down</returns>
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
