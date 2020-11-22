using System;

namespace _03.Telephony.Exceptions
{
    public class InvalidNumberException : Exception
    {
        private const string INVALID_NUMBER_MSG = "Invalid number!";

        public InvalidNumberException()
            :base(INVALID_NUMBER_MSG)
        {
            
        }

        public InvalidNumberException(string message)
            :base(message)
        {

        }
    }
}