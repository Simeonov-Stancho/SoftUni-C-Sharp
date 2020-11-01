using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person();
            firstPerson.Name = "Pesho";
            firstPerson.Age = 20;

            Person secondPerson = new Person();
            secondPerson.Name = "Gosho";
            secondPerson.Age = 18;

            Person thirdPerson = new Person();
            thirdPerson.Name = "Stamat";
            thirdPerson.Age = 43;

            Console.WriteLine($"{firstPerson.Name} {firstPerson.Age}" +
                $"\n{secondPerson.Name} {secondPerson.Age}" +
                $"\n{thirdPerson.Name} {thirdPerson.Age}");

            Person somePerson = new Person("Dimitrichko", 33);
        }
    }
}
