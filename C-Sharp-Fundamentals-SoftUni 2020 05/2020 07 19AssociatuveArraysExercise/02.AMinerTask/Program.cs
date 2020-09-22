using System;
using System.Collections.Generic;
using System.Threading;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = string.Empty;
            Dictionary<string, int> resourcesQuantity = new Dictionary<string, int>();

            while ((key = Console.ReadLine()) != "stop")
            {
                if (!resourcesQuantity.ContainsKey(key))
                {
                    resourcesQuantity.Add(key, 0);
                }

                string value = Console.ReadLine();
                resourcesQuantity[key] += int.Parse(value);
            }

            foreach (var pairs in resourcesQuantity)
            {
                Console.WriteLine(pairs.Key + " -> " + pairs.Value);
            }
        }
    }
}
