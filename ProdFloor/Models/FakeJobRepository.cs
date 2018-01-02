using System.Collections.Generic;
using System.Linq;

namespace ProdFloor.Models
{
    public class FakeJobRepository /*: IJobRepository*/
    {
        public IQueryable<Job> Jobs => 
            new List<Job> {
            new Job { Name = "BRENTWOOD CONDOS", JobNum = 2017088571,
                PO = 3398238, Cust = "OTIS-MP", JobState = "Texas"},
            new Job { Name = "Job Name 2", JobNum = 2017088362,
                PO = 3398175, Cust = "FAKE-2", JobState = "California"},
            new Job { Name = "PACIFIC PALISADES LAUSD CHARTER HIGH SCHOOL",
                JobNum = 2017088536,PO = 3397819, Cust = "CAEE2999",
                JobState = "California"},
            new Job { Name = "SMC ADMIN", JobNum = 2017088535,
                PO = 3397817, Cust = "CAEE3000", JobState = "California"}
        }.AsQueryable<Job>();
    }
}
