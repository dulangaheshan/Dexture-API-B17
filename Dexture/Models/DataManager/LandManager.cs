using Dexture.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.DataManager
{
    public class LandManager : IDataRepository<Land>
    {
        readonly Context _landContext;

        public LandManager(Context context)
        {
            _landContext = context;
        }

        public void Add(Land entity)
        {
            _landContext.Lands.Add(entity);
            _landContext.SaveChanges();
        }

        public long AddData(Land entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Land entity)
        {
            throw new NotImplementedException();
        }

        public Land Get(long id)
        {
           return _landContext.Lands.Where(e => e.LandId == id).SingleOrDefault();
        }

        public Prediction Get(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Land> GetAll()
        {
            return _landContext.Lands.ToList();
        }

        public IEnumerable<Land> Getselected(long id)
        {
            var data = _landContext.Lands.Where(e => e.FarmerId == id).ToList();
            return data;
            //throw new NotImplementedException();
        }

        public void Update(Prediction dbEntity, Prediction entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Land dbEntity, Land entity)
        {
            throw new NotImplementedException();
        }

        //Land IDataRepository<Land>.Get(long id)
        //{
        //    throw new NotImplementedException();
        //}

        Land IDataRepository<Land>.Get(string email)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Land> IDataRepository<Land>.Getselected(long id)
        {
            var data = _landContext.Lands.Where(e => e.FarmerId == id).ToList();
            return data;
        }
    }
}
