// <copyright file="ConsoleUserInterface.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;

    /// <summary>
    /// Responsible for retrieving commands from the user via the console.
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        /// <summary>
        /// Triggered when a new command is entered from the user (via the console).
        /// </summary>
        public event CommandArrivedEventHandler CommandArrived;

        /// <summary>
        /// Wait for the user to enter a command on the console, read it and triggers the <see cref="ConsoleUserInterface.CommandArrived"/> event.
        /// </summary>
        /// <param name="isKingsTurn">True if it is king's turn.</param>
        public void ListenForCommand(bool isKingsTurn)
        {
            if (isKingsTurn)
            {
                Console.Write("King's turn: ");
            }
            else
            {
                Console.Write("Pawn's turn: ");
            }

            string command = Console.ReadLine();
            this.CommandArrived(this, new CommandArrivedArgs(command));
        }
    }
}
