// <copyright file="CommandArrivedArgs.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;

    public class CommandArrivedArgs : EventArgs
    {
        public CommandArrivedArgs(string command)
            : base()
        {
            this.Command = command;
        }

        public string Command { get; private set; }
    }
}
