// <copyright file="GameOverEventArgs.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;

    /// <summary>
    /// Represents a set of arguments, containing information about the finished game.
    /// </summary>
    public class GameOverEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameOverEventArgs"/> class.
        /// </summary>
        /// <param name="gameState">The last game state of the finished game.</param>
        public GameOverEventArgs(GameState gameState)
            : base()
        {
            this.GameState = gameState;
        }

        /// <summary>
        /// Gets the last game state of the finished game.
        /// </summary>
        public GameState GameState { get; private set; }
    }
}
