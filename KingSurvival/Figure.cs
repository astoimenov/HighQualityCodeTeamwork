namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    public abstract class Figure
    {
        private char name;

        public Figure(char name)
        {
            this.Name = name;
        }

        public char Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if ((value >= 'a' && value <= 'z') ||
                    (value >= 'A' && value <= 'Z'))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The name of the figure must be an upper or lower latin letter (a-z or A-Z).");
                }
            }
        }

        /// <summary>
        /// Determines if the Figure can move to a given new position
        /// </summary>
        /// <param name="from">Current position of the Figure</param>
        /// <param name="to">The new position which the Figure will move to</param>
        /// <param name="attacksDownToUp"></param>
        /// <returns>Returns true if the Figure can move to the given new position. Otherwise, returns false.</returns>
        public abstract bool CanMove(Vector from, Vector to, bool attacksDownToUp = true);

        /// <summary>
        /// Determines which are the possible positions of a Figure object for moving up and down
        /// </summary>
        /// <param name="initialPosition">Current position of the Figure</param>
        /// <returns>Returns a list of possible positions of the Figure object for moving up and down</returns>
        public abstract List<Vector> GetPossibleNewPositions(Vector initialPosition, bool attacksDownToUp = true);
    }
}
