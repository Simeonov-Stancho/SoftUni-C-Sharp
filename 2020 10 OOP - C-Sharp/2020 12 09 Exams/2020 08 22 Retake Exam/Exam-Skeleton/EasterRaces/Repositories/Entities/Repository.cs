﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;

        protected Repository()
        {
            this.models = new List<T>();
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.models.ToList().AsReadOnly();
        }

        public T GetByName(string name)
        {
            return this.models.FirstOrDefault(t => t.GetType().Name == name);
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
