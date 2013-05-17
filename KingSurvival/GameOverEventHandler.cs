// <copyright file="GameOverEventHandler.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;

    /// <summary>
    /// Represents an event handler for <see cref="Engine.GameOver"/> event.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">Arguments, containing the last game state before the game over.</param>
    public delegate void GameOverEventHandler(object sender, GameOverEventArgs e);
}
