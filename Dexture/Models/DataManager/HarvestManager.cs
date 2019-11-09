using Dexture.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.DataManager
{
    public class HarvestManager : IDataRepository<Harvest>
    {
        readonly Context _harvestContext;

        public HarvestManager(Context context)
        {
            _harvestContext = context;
        }


        public void Add(Harvest entity)
        {
            _harvestContext.Harvests.Add(entity);
            // yield return entity.HarvestId;
            _harvestContext.SaveChanges();
           
        }

        public long AddData(Harvest entity)
        {
            _harvestContext.Harvests.Add(entity);
            _harvestContext.SaveChanges();
            return entity.HarvestId;

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
