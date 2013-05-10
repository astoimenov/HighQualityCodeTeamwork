using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    interface IUserInterface
    {
        event CommandArrivedEventHandler CommandArrived;

        void ListenForCommand(bool isKingsTurn);
    }
}
