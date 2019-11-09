using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.Repository
{
    public class Land_Harvest
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int LAnd_Harvest { get; set; }
            [JsonIgnore]
            public virtual Harvest Harvests { get; set; }

            [JsonIgnore]
            public virtual Land Lands { get; set; }
            
        //public long harvestId { get; set; }
        //public long landId { get; set; }
        
    }
}
