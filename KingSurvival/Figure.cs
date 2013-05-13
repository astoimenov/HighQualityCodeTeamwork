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

        public abstract bool CanMove(Vector from, Vector to, bool attacksDownToUp = true);

        public abstract List<Vector> GetPossibleNewPositions(Vector initialPosition, bool attacksDownToUp = true);
    }
}
