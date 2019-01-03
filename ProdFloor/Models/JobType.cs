using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProdFloor.Models
{
    public class JobType
    {
        public int JobTypeID { get; set; }

        [Required(ErrorMessage = "Please enter a job type name")]
        public string Name { get; set; }

    }
}
