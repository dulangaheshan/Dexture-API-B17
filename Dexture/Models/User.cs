using Dexture.Models.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dexture.Models
{
    [Table("Users")]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nic { get; set; }
        public string ContactNo { get; set; }
        public string PersonalAddress { get; set; }

        public string Password { get; set; }

    }
    public class AgricultureOfficer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgricultureOfficerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nic { get; set; }
        public string ContactNo { get; set; }
        public string PersonalAddress { get; set; }

        public string Password { get; set; }
    }

    public class Buyer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuyerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nic { get; set; }
        public string ContactNo { get; set; }
        public string PersonalAddress { get; set; }

        public string Password { get; set; }
    }

    public class Farmer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FarmerId { get; set; }

        public string GramaNiladariDivision { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nic { get; set; }
        public string ContactNo { get; set; }
        public string PersonalAddress { get; set; }

        public string Password { get; set; }

        public Boolean IsAccepted { get; set; }
        [ForeignKey("FarmerId")]
        public ICollection<Land> Lands { get; set; }

        [ForeignKey("FarmerId")]
        public ICollection<FutureCultivation> FutureCultivations { get; set; }
        
    }


}

