namespace KingSurvival
{
    using System;

    public struct Vector
    {
        public Vector(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

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
            hash = (37 * hash) + this.X;
            hash = (37 * hash) + this.Y;
            return hash;
        }
    }
}
