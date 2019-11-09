using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.Repository
{
    public class Generate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenerateId { get; set; }
        [JsonIgnore]
        public virtual Harvest Harvests { get; set; }

        [JsonIgnore]
        public virtual FutureCultivation FutureCultivations { get; set; }
    }
}
