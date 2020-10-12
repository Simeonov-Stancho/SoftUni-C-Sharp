using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;
        private int count;

        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new Dictionary<string, Car>();
            count = 0;
        }

        public Dictionary<string, Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count
        {
            get { return count; }
        }

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }

            if (count == capacity)
            {
                return $"Parking is full!";
            }

            cars.Add(car.RegistrationNumber, car);
            count++;
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.ContainsKey(registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }

            cars.Remove(registrationNumber);
            count--;
            return $"Successfully removed { registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return cars[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                if (cars.ContainsKey(number))
                {
                    cars.Remove(number);
                    count--;
                }
            }
        }
    }
}
