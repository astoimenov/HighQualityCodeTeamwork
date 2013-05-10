using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    class InvalidMovementException : Exception
    {
        public InvalidMovementException(string message)
            : base(message)
        {
        }

        public InvalidMovementException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
