﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => this.models;

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
       => this.models.FirstOrDefault(m => m.RaceName == name);

        public bool Remove(IRace model)
        => this.models.Remove(model);
    }
}