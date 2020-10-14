using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.Data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public List<Pet> Data
        {
            get { return data; }
            set { this.data = value; }
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Pet pet)
        {
            if (this.Capacity > this.Count)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            bool isExist = data.Exists(p => p.Name == name);

            if (isExist)
            {
                data.RemoveAll(p => p.Name == name);
            }

            return isExist;
        }

        public Pet GetPet(string name, string owner)
        {
            int index = -1;
            for (int i = 0; i < this.data.Count; i++)
            {
                string currentPetName = this.data[i].Name;
                string currentOwner = this.data[i].Owner;

                if (currentPetName == name && currentOwner == owner)
                {
                    index = i;
                }
            }

            if (index != -1)
            {
                Pet currentPet = this.data[index];
                return currentPet;
            }

            else
            {
                return null;
            }
        }

        public Pet GetOldestPet()
        {
            return this.data.Find(p => p.Age == data.Max(p => p.Age));
        }

        public string GetStatistics()
        {
            StringBuilder stat = new StringBuilder();
            stat.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                stat.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return stat.ToString().Trim();
        }
    }
}
