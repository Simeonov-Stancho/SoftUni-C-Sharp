using _05.BirthdayCelebrations.Contracts;

namespace _05.BirthdayCelebrations.Models
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