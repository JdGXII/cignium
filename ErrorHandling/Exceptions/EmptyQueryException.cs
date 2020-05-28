using System;

namespace ErrorHandling.Exceptions
{
    public class EmptyQueryException : Exception
    {
        override
        public string Message { get => "Queries list is empty. ";  }
    }
}
