using Dexture.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.DataManager
{
    public class AuctionManager : IDataRepository<Auction>
    {
        readonly Context _AuctionContext;

        public AuctionManager(Context context)
        {
            _AuctionContext = context;
        }

        public void Add(Auction entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Auction entity)
        {
            throw new NotImplementedException();
        }

        public Auction Get(long id)
        {
            throw new NotImplementedException();
        }

        public Auction Get(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auction> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auction> Getselected(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auction dbEntity, Auction entity)
        {
            throw new NotImplementedException();
        }
    }
}
