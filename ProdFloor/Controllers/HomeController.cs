using Microsoft.AspNetCore.Mvc;
using ProdFloor.Models;
using ProdFloor.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ProdFloor.Controllers
{
    [Authorize(Roles ="Admin,Engineer")]
    public class HomeController : Controller
    {
        private IJobRepository repository;
        public int PageSize = 2;
        private UserManager<AppUser> userManager;

        public HomeController(IJobRepository repo, UserManager<AppUser> userMrg)
        {
            repository = repo;
            userManager = userMrg;
        }

        private async Task<bool> GetCurrentUser(string role)
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);

            bool isInRole = await userManager.IsInRoleAsync(user, role);

            return isInRole;
        }

        public ActionResult Index(int pendingJobPage = 1,
            int productionJobPage = 1)
        {
            bool engineer = GetCurrentUser("Engineer").Result;
            
            if(engineer)
            {
                return View("EngineerDashBoard", new DashboardIndexViewModel
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
            }

            return View("AdminDashBoard", new DashboardIndexViewModel
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
        }

    }

}
