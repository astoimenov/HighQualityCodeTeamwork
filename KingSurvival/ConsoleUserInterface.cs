using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    class ConsoleUserInterface : IUserInterface
    {
        public event CommandArrivedEventHandler CommandArrived;

        public void ListenForCommand()
        {
            string command = Console.ReadLine();
            this.CommandArrived(this, new CommandArrivedArgs(command));
        }
    }
}
