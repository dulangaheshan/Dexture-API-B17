using Dexture.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.DataManager
{
    public class FutureCultivationManager : IDataRepository<FutureCultivation>
    {
        readonly Context _fututeCultivationContext;

       public FutureCultivationManager(Context context)
        {
            _fututeCultivationContext = context;
        }

        public void Add(FutureCultivation entity)
        {
            _fututeCultivationContext.FutureCultivations.Add(entity);
            _fututeCultivationContext.SaveChanges();
        }

        public void Delete(FutureCultivation entity)
        {
            throw new NotImplementedException();
        }

        public FutureCultivation Get(long id)
        {
            throw new NotImplementedException();
        }

        public FutureCultivation Get(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FutureCultivation> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FutureCultivation> Getselected(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(FutureCultivation dbEntity, FutureCultivation entity)
        {
            throw new NotImplementedException();
        }
    }
}
