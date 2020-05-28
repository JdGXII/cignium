using System;

namespace ErrorHandling.Exceptions
{
    public class NoConfigurationSectionFound : Exception
    {
        override
        public string Message { get => "No configuration section found"; }
    }
}
