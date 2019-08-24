using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.Repository
{
    public class FutureCultivation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CultivationId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }

        public String Date { get; set; }
       
    }
}
