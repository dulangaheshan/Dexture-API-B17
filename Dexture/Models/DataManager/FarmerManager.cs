using Dexture.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.DataManager
{
    public class FarmerManager : IDataRepository<Farmer>
    {
        readonly Context _farmerContext;

        public FarmerManager(Context context)
        {
            _farmerContext = context;
        }
        public void Add(Farmer entity)
        {
            _farmerContext.Farmers.Add(entity);
            _farmerContext.SaveChanges();
        }

        public void Delete(Farmer entity)
        {
            throw new NotImplementedException();
        }

        public Farmer Get(long id)
        {
            return _farmerContext.Farmers
                .FirstOrDefault(e => e.FarmerId == id);
        }

        public Farmer Get(string email)
        {
            return _farmerContext.Farmers
                .FirstOrDefault(e => e.Email == email);
        }

        public IEnumerable<Farmer> GetAll()
        {
            return _farmerContext.Farmers.ToList();
        }

        public IEnumerable<Farmer> Getselected(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Farmer dbEntity, Farmer entity)
        {
            //dbEntity.FirstName = entity.FirstName;
            //dbEntity.LastName = entity.LastName;
            //dbEntity.Nic = entity.Nic;
            dbEntity.IsAccepted = true;
            _farmerContext.SaveChanges();
        }
    }
}
