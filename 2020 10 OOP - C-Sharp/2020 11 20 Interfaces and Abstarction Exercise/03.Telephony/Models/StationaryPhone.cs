using System.Linq;
using _03.Telephony.Exceptions;

namespace _03.Telephony.Contracts
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Dialing... {number}";
        }
    }
}