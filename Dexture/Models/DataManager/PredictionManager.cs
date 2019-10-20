using Dexture.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.DataManager
{
    public class PredictionManager : IDataRepository<Prediction>
    {
        readonly Context _predictionContext;

        public PredictionManager(Context context)
        {
            _predictionContext = context;
        }

        public void Add(Prediction entity)
        {
            _predictionContext.predictions.Add(entity);
            _predictionContext.SaveChanges();
        }

        public void Delete(Prediction entity)
        {
            _predictionContext.Remove(entity);
        }

        public Prediction Get(long id)
        {

            throw new NotImplementedException();
        }

        public Prediction Get(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prediction> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prediction> Getselected(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Prediction dbEntity, Prediction entity)
        {
            throw new NotImplementedException();
        }
    }
}
