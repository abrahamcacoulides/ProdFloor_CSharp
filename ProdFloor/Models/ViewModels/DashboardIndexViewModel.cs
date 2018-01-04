using System.Collections.Generic;
using ProdFloor.Models;

namespace ProdFloor.Models.ViewModels
{
    public class DashboardIndexViewModel
    {
        public IEnumerable<Job> PendingJobs { get; set; }
        public PagingInfo PendingJobsPagingInfo { get; set; }
        public IEnumerable<Job> ProductionJobs { get; set; }
        public PagingInfo ProductionJobsPagingInfo { get; set; }
    }
}
