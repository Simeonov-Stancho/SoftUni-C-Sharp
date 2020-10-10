using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstConstructor = new Person();
            Person secondConstructor = new Person(-1);
            Person thirdConstructor = new Person("Dimitrichko", 33);

            Console.WriteLine(firstConstructor.Name + " " + firstConstructor.Age);
            Console.WriteLine(secondConstructor.Name + " " + secondConstructor.Age);
            Console.WriteLine(thirdConstructor.Name + " " + thirdConstructor.Age);
        }
    }
}
