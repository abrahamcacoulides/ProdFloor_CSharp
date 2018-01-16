using Microsoft.AspNetCore.Mvc;
using ProdFloor.Models;
using ProdFloor.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ProdFloor.Controllers
{
    public class HomeController : Controller
    {
        private IJobRepository repository;
        public int PageSize = 2;

        public HomeController(IJobRepository repo)
        {
            repository = repo;
        }

        //[Authorize]
        public ActionResult Index(int pendingJobPage = 1,
            int productionJobPage = 1)
            => View(new DashboardIndexViewModel
            {
                PendingJobs = repository.Jobs
                .OrderBy(p => p.JobID)
                .Skip((pendingJobPage - 1) * PageSize)
                .Take(PageSize),
                PendingJobsPagingInfo = new PagingInfo
                {
                    CurrentPage = pendingJobPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Jobs.Count()
                },
                ProductionJobs = repository.Jobs
                .OrderBy(p => p.JobID)
                .Skip((productionJobPage - 1) * PageSize)
                .Take(PageSize),
                ProductionJobsPagingInfo = new PagingInfo
                {
                    CurrentPage = productionJobPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Jobs.Count()
                }
            });

        //public ViewResult Index() => View();
    }
}
