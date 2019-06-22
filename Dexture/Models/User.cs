using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nic { get; set; }
        public string ContactNo { get; set; }
        public string PersonalAddress { get; set; }

    }

    public class Admin : User
    {
        public int AdminId { get; set; }
    }

    public class AgricultureOfficer : User
    {
        public int AgricultureOfficerId { get; set; }
    }

    public class Farmer : User
    {
        public int FarmerId { get; set; }

        public string GramaNiladariDivision { get; set; }
    }


}
