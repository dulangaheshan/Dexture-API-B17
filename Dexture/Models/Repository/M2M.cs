using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.Repository
{
    public class M2M_FC_To_Harverst
    {
        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }
        public int CultivationId { get; set; }

        public FutureCultivation FutureCultivation { get; set; }


    }


}
