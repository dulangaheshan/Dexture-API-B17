﻿using Dexture.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.DataManager
{
    public class HarvestManager : IDataRepository<Harvest>
    {
        readonly Context _harvestContext;
        public void Add(Harvest entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Harvest entity)
        {
            throw new NotImplementedException();
        }

        public Harvest Get(long id)
        {
            throw new NotImplementedException();
        }

        public Harvest Get(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Harvest> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Harvest> Getselected(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Harvest dbEntity, Harvest entity)
        {
            throw new NotImplementedException();
        }
    }
}