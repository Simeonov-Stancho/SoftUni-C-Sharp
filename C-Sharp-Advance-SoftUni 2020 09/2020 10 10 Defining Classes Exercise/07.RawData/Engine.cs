using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Engine
    {
        private int engineSpeed;
        private int enginePOwer;

        public Engine(int engineSpeed, int enginePOwer)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePOwer;
        }

        public int EngineSpeed
        {
            get { return engineSpeed; }
            set { engineSpeed = value; }
        }

        public int EnginePower
        {
            get { return enginePOwer; }
            set { enginePOwer = value; }
        }
    }
}
