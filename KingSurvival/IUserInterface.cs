// <copyright file="IUserInterface.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    /// <summary>
    /// Describes an abstract interface for retrieving information from the user.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Triggered when a new command is passed by the user (no matter how).
        /// </summary>
        event CommandArrivedEventHandler CommandArrived;

        /// <summary>
        /// Start listening for a new command.
        /// </summary>
        /// <param name="isKingsTurn">True if it is king's turn.</param>
        void ListenForCommand(bool isKingsTurn);
    }
}
