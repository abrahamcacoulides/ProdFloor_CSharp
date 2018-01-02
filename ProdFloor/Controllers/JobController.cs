using Microsoft.AspNetCore.Mvc;
using ProdFloor.Models;
using ProdFloor.Models.ViewModels;
using System.Linq;

namespace ProdFloor.Controllers
{
    public class JobController : Controller
    {
        private IJobRepository repository;
        public int PageSize = 4;

        public JobController(IJobRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string jobType, int JobPage = 1)
            => View(new JobsListViewModel
            {
                Jobs = repository.Jobs
                .Where(j => jobType == null || j.JobType == jobType)
                .OrderBy(p => p.JobID)
                .Skip((JobPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = JobPage,
                    ItemsPerPage = PageSize,
                    TotalItems =jobType == null ?
                    repository.Jobs.Count() :
                    repository.Jobs.Where(e =>
                    e.JobType == jobType).Count()
                },
                CurrentJobType = jobType
            });

        public ViewResult Edit(int jobId) =>
            View(repository.Jobs
                .FirstOrDefault(j => j.JobID == jobId));
    }
}
