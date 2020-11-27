using System;

namespace _07.MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string DEF_EXC_MSG = "Mission alredy finished!";

        public InvalidMissionCompletionException()
            :base(DEF_EXC_MSG)
        {

        }

        public InvalidMissionCompletionException(string message) : base(message)
        {

        }
    }
}
