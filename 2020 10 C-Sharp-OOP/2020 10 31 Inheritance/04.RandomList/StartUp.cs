using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("asd");
            list.Add("bmw");
            list.Add("audi");
            list.Add("begai");

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
        }
    }
}
