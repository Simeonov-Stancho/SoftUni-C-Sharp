using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Common.Exceptions
{
    public class Exceptions : Exception
    {
        

        public Exceptions()
        {

        }

        public Exceptions(string message) 
            : base(message)
        {

        }
    }
}
