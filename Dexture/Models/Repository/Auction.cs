using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.Repository
{
    public class Auction
    {
        [ForeignKey("Harvest")]
        public int HarvestID { get; set; }
        public int AuctionID { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
        public double  Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Harvest Harvest { get; set; }
    }
}
