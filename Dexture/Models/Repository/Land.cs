using Dexture.Models.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models
{
    public class Land
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LandId { get; set; }
        public double Size { get; set; }
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int FarmerId { get; set; }
        [JsonIgnore]
        public virtual Farmer Farmers{ get; set; }
        [ForeignKey("LandId")]
        public ICollection<Land_Harvest> Land_Harvests { get; set; }



    }
}
