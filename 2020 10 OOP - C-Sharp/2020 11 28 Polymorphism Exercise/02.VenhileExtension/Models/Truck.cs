namespace _01.VehiclesKristiyanIvanov.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONS_INC = 1.6;
        private const double REFUEL_PERCENT = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption
        {
            get { return base.FuelConsumption + FUEL_CONS_INC; }
        }

        public override void Refuel(double liters)
        {
            if (liters > this.TankCapacity)
            {
                base.Refuel(liters);
            }

            else
            {
                base.Refuel(liters * REFUEL_PERCENT);
            }
        }
    }
}
