﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public class CommandArrivedArgs : EventArgs
    {
        public string Command { get; private set; }

        public CommandArrivedArgs(string command)
            : base()
        {
            this.Command = command;
        }
    }
}
