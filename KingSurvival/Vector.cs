// <copyright file="Vector.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;

    public struct Vector
    {
        public Vector(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        /// <summary>
        /// Overritten Object.Equals(Object) method. Determines whether the specified Vector 
        /// object is equal to the current Vector object. Two Vector objects are equal if 
        /// they have the same values for their Vector.X and Vector.Y properties.
        /// </summary>
        /// <param name="obj">the Vector object to be 
        /// compared with the current Vector object</param>
        /// <returns>returns true if the Vector.X and Vector.Y properties of two Vector objects 
        /// are equal. Otherwise, returns false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                Vector other = (Vector)obj;
                if (this.X == other.X && this.Y == other.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 71; // Should be prime number
            hash = (37 * hash) + this.X;
            hash = (37 * hash) + this.Y;
            return hash;
        }
    }
}
