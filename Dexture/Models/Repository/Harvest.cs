using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.Repository
{
    public class Harvest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HarvestId { get; set; }
        public String Name { get; set; }
        public String SellingQuantity { get; set; }
        public String AllQuantity { get; set; }
        [ForeignKey("HarvestId")]
        public ICollection<Generate> generates { get; set; }

        public virtual Auction Auction { get; set; }
    }
}
