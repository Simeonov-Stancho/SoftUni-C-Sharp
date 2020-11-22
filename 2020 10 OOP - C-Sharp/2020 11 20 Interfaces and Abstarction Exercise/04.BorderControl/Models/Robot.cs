using _04.BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    public class Robot : IInhabitable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.ID = id;
        }

        public string Model { get; }
        public string ID { get; }
    }
}
