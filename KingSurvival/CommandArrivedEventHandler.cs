// <copyright file="CommandArrivedEventHandler.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;

    /// <summary>
    /// Represents an event handler for <see cref="IUserInterface.CommandArrived"/> event.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">Arguments, containing information about the arrived command.</param>
    public delegate void CommandArrivedEventHandler(object sender, CommandArrivedArgs e);
}
