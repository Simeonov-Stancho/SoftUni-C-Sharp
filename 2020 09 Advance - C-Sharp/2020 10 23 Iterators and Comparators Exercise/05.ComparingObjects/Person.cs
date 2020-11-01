using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            int result = 1;
            if (other != null)
            {
                result = this.Name.CompareTo(other.Name);

                if (result == 0)
                {
                    result = this.Age.CompareTo(other.Age);

                    if (result == 0)
                    {
                        result = this.Town.CompareTo(other.Town);
                    }
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this.CompareTo(person) == 0;
            }

            return false;
        }
    }
}
