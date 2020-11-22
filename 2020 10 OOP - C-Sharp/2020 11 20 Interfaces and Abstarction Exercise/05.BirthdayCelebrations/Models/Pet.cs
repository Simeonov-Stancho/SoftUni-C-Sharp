using _05.BirthdayCelebrations.Contracts;

namespace _05.BirthdayCelebrations.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; }
        public string Birthdate { get; }
    }
}