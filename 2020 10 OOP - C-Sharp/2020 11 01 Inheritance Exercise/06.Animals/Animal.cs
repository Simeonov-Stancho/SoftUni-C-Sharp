﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public virtual string ProduceSound()
        {
            return "NoSuchSound";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(this.ProduceSound());
            return sb.ToString().Trim();
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
