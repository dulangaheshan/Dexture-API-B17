using Dexture.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.DataManager
{
    public class AdminManager : IDataRepository<Admin>
    {
        readonly Context _adminContext;

        public AdminManager(Context context)
        {
            _adminContext = context;
        }

        public void Add(Admin entity)
        {
            _adminContext.Admins.Add(entity);
            _adminContext.SaveChanges();
        }

        public void Delete(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Admin Get(long id)
        {
            throw new NotImplementedException();
        }

        public Admin Get(string email)
        {
            return _adminContext.Admins
                .FirstOrDefault(e => e.Email == email);
        }

        public IEnumerable<Admin> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Admin> Getselected(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin dbEntity, Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
