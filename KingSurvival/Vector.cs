using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public struct Vector
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Vector(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                Vector other = (Vector)obj;
                if (this.X == other.X && this.Y == other.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 71; // Should be prime number
            hash = 37 * hash + this.X;
            hash = 37 * hash + this.Y;
            return hash;
        }
    }
}
