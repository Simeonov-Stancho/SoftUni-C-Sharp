using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<TFirst,TSecond>
    {
        public Tuple(TFirst firstElement, TSecond secondElement)
        {
            this.FirstElement = firstElement;
            this.SecondElement = secondElement;
        }

        public TFirst FirstElement { get; set; }
        public TSecond SecondElement { get; set; }

        public override string ToString()
        {
            return $"{this.FirstElement} -> {this.SecondElement}".ToString().Trim();
        }
    }
}
