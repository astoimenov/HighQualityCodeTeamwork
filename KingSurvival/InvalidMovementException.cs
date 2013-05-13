// <copyright file="InvalidMovementException.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;

    /// <summary>
    /// The exception is thrown when a movement command 
    /// can't be executed because the movement is invalid and can't be done.
    /// </summary>
    public class InvalidMovementException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMovementException"/> class.
        /// </summary>
        /// <param name="message">A message describing the exception.</param>
        public InvalidMovementException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMovementException"/> class.
        /// </summary>
        /// <param name="message">A message describing the exception.</param>
        /// <param name="innerException">An inner exception which caused the current thrown exception.</param>
        public InvalidMovementException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
