using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Snake : Reptile
    {
        public Snake(string name) : base(name)
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
