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
