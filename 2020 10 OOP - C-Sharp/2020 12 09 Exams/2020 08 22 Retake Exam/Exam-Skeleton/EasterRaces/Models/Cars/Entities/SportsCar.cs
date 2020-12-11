namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double CUBIC_CENTIMETERS = 3000;
        private const int MIN_HP = 250;
        private const int MAX_HP = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETERS, MIN_HP, MAX_HP)
        {

        }
    }
}
