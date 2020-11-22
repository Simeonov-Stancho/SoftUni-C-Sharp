using _05.BirthdayCelebrations.Contracts;

namespace _05.BirthdayCelebrations.Models
{
    public class Citizen : IInhabitable, IBirthable

    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string ID { get; }
        public string Birthdate { get; }
    }
}