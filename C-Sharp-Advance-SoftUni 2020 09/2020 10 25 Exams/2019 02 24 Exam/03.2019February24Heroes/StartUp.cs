using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize the repository
            HeroRepository repository = new HeroRepository();
            //Initialize entity
            Item item = new Item(23, 35, 48);
            //Print Item
            Console.WriteLine(item);

            //Item:
            //    * Strength: 23
            //    * Ability: 35
            //    * Intelligence: 48

            Console.WriteLine("*********************************");
            //Initialize entity
            Hero hero = new Hero("Hero Name", 24, item);
            //Print Hero
            Console.WriteLine(hero);
            Console.WriteLine("*********************************");
            //Hero: Hero Name - 24lvl
            //Item:
            //    * Strength: 23
            //    * Ability: 35
            //    * Intelligence: 48

            //Add Hero
            repository.Add(hero);
            Console.WriteLine(repository);
            Console.WriteLine("*********************************");
            //Remove Hero
            repository.Remove("Hero Name");
            Console.WriteLine(repository);
            Console.WriteLine("*********************************");

            Item secondItem = new Item(100, 20, 13);
            Hero secondHero = new Hero("Second Hero Name", 125, secondItem);

            //Add Heroes
            repository.Add(hero);
            repository.Add(secondHero);
            Console.WriteLine(repository);
            Console.WriteLine("*********************************");

            Hero heroStrength = repository.GetHeroWithHighestStrength();
            Console.WriteLine(heroStrength);// Hero with name Second Hero
            Console.WriteLine("*********************************");
            Hero heroAbility = repository.GetHeroWithHighestAbility();
            Console.WriteLine(heroAbility);// Hero with name Hero Name
            Console.WriteLine("*********************************");
            Hero heroIntelligence = repository.GetHeroWithHighestIntelligence();
            Console.WriteLine(heroIntelligence);// Hero with name Hero
            Console.WriteLine("*********************************");

            Console.WriteLine(repository.Count); //2
            Console.WriteLine("*********************************");

            Console.WriteLine(repository);
            //Hero: Hero Name - 24lvl
            //Item:
            //*Strength: 23
            //    * Ability: 35
            //    * Intelligence: 48
            //Hero: Second Hero Name - 125lvl
            //Item:
            //    * Strength: 100
            //    * Ability: 20
            //    * Intelligence: 13
            Console.WriteLine("*********************************");
        }
    }
}