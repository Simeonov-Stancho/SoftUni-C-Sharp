using _04.BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    public class Citizen : IInhabitable

    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }

        public string Name { get; }
        public int Age { get; }
        public string ID { get; }
    }
}
