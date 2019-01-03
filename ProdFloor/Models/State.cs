using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProdFloor.Models
{
    public class State
    { 
        public int StateID { get; set; }

        public string Country { get; set; }

        public string Name { get; set; }
    }
}
