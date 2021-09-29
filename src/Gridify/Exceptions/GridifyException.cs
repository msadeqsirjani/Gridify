using System;

namespace Gridify.Exceptions
{
    public class GridifyException : Exception
    {
        public GridifyException() { }

        public GridifyException(string message) : base(message) { }

        public GridifyException(string message, Exception inner) : base(message, inner) { }
    }
}
