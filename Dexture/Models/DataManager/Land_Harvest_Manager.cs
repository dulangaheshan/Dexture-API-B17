using Dexture.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.DataManager
{
    public class Land_Harvest_Manager : IDataRepository<Land_Harvest>
    {
        readonly Context _Land_Harvest;
        public Land_Harvest_Manager(Context context)
        {
            _Land_Harvest = context;
        }

        public void Add(Land_Harvest entity)
        {
            _Land_Harvest.land_Harvests.Add(entity);
            _Land_Harvest.SaveChanges();
        }

        public long AddData(Land_Harvest entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Land_Harvest entity)
        {
            throw new NotImplementedException();
        }

        public Land_Harvest Get(long id)
        {
            throw new NotImplementedException();
        }

        public Land_Harvest Get(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Land_Harvest> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Land_Harvest> Getselected(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Land_Harvest dbEntity, Land_Harvest entity)
        {
            throw new NotImplementedException();
        }
    }
}
