// <copyright file="InvalidPositionException.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;

    /// <summary>
    /// The exception is thrown when an invalid position is tried to be accessed or manipulated.
    /// </summary>
    public class InvalidPositionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPositionException"/> class.
        /// </summary>
        /// <param name="position">The position which is determined as invalid.</param>
        /// <param name="message">A message describing the exception.</param>
        public InvalidPositionException(Vector position, string message)
            : base(message)
        {
            this.Position = position;
        }

        /// <summary>
        /// Gets the position which is determined as invalid.
        /// </summary>
        public Vector Position { get; private set; }
    }
}
