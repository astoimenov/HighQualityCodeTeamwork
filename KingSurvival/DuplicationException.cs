namespace KingSurvival
{
    using System;

    public class DuplicationException<T> : Exception
    {
        public DuplicationException(T duplicatedObject, string message)
            : base(message)
        {
            this.Duplicate = duplicatedObject;
        }

        public T Duplicate { get; private set; }
    }
}
