using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.Repository
{
    public class Prediction
    {
        public int PredictionID { get; set; }
        public double Quantity { get; set; }
        public string Date { get; set; }
        public double DemandRate { get; set; }
        [JsonIgnore]
        public virtual FutureCultivation FutureCultivations { get; set; }
        [JsonIgnore]
        public virtual Harvest Harvests { get; set; }


    }
}
