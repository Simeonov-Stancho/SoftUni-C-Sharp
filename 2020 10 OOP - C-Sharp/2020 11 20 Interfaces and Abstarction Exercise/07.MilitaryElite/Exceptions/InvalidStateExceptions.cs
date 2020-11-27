using System;

namespace _07.MilitaryElite.Exceptions
{
    public class InvalidStateExceptions : Exception
    {
        private const string INVALID_STATE_EXC_MSG = "Invalid mission state!";

        public InvalidStateExceptions()
            :base(INVALID_STATE_EXC_MSG)
        {

        }

        public InvalidStateExceptions(string message) 
            : base(message)
        {

        }
    }
}
