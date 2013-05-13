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
