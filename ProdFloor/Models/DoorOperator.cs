using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProdFloor.Models
{
    public class DoorOperator
    {
        public int DoorOperatorID { get; set; }

        public string Style { get; set; }

        public string Brand { get; set; }

        public string Name { get; set; }

    }
}
