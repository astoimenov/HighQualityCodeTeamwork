using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public class DuplicationException<T> : Exception
    {
        public T Duplicate { get; private set; }

        public DuplicationException(T duplicatedObject, string message)
            : base(message)
        {
            this.Duplicate = duplicatedObject;
        }
    }
}
