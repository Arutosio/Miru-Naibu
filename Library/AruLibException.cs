using System;

namespace Miru_Naibu.Library
{
    [Serializable]
    public class AruLibException : Exception
    {
        public AruLibException() { }

        public AruLibException(string message)
            : base(message) { }

        public AruLibException(string message, Exception inner)
            : base(message, inner) { }
    }
}