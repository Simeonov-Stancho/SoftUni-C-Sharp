using System.Linq;

using _03.Telephony.Exceptions;

namespace _03.Telephony.Models
{
    public class SmartPhone
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {number}";
        }

        public string Brawse(string site)
        {
            if (site.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {site}!";
        }
    }
}
