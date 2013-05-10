using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException(Vector position, string message)
            : base(message)
        {
            this.Position = position;
        }

        public Vector Position { get; private set; }
    }
}
