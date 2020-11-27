using System;

using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enumeration;
using _07.MilitaryElite.Exceptions;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParseState(state);
        }
        public string CodeName { get; private set; }

        public State State { get; private set; }

        private State TryParseState(string stateStr)
        {
            bool parsed = Enum.TryParse<State>(stateStr, out State state);

            if (!parsed)
            {
                throw new InvalidStateExceptions();
            }

            return state;
        }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }

            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
