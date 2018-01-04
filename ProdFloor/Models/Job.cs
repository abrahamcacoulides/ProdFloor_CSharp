using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProdFloor.Models
{
    public class Job
    {
        public int JobID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Job Type")]
        public string JobType { get; set; }

        [Required(ErrorMessage = "Please enter a Job Num")]
        public int JobNum { get; set; }

        [Required(ErrorMessage = "Please enter a PO")]
        public int PO { get; set; }

        [Required(ErrorMessage = "Please enter a Shipping Date")]
        public DateTime ShipDate { get; set; }

        [Required(ErrorMessage = "Please enter a Customer Number")]
        public string Cust { get; set; }

        [Required(ErrorMessage = "Please enter a Contractor")]
        public string Contractor { get; set; }

        [Required(ErrorMessage = "Please enter a State")]
        public string JobState { get; set; }

        [Required(ErrorMessage = "Please enter a Safety Code")]
        public string SafetyCode { get; set; }
    }
}
