using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Lizard : Reptile
    {
        public Lizard(string name) : base(name)
        {
            this.Name = name;
        }

        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
}
