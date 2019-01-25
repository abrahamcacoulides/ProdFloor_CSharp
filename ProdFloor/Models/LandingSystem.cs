using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProdFloor.Models
{
    public class LandingSystem
    {
        public int LandingSystemID { get; set; }

        [Required(ErrorMessage = "Please enter a Model")]
        public string UsedIn { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
    }
}
