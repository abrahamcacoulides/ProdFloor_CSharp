using Microsoft.AspNetCore.Mvc;
using ProdFloor.Models;
using ProdFloor.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        public ViewResult List(string jobType, int jobPage = 1)
            => View(new JobsListViewModel
            {
                Jobs = repository.Jobs
                .Where(j => jobType == null || j.JobType == jobType)
                .OrderBy(p => p.JobID)
                .Skip((jobPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = jobPage,
                    ItemsPerPage = PageSize,
                    TotalItems =jobType == null ?
                    repository.Jobs.Count() :
                    repository.Jobs.Where(e =>
                    e.JobType == jobType).Count()
                },
                CurrentJobType = jobType
            });

        public ViewResult Edit(int ID) =>
            View(repository.Jobs
                .FirstOrDefault(j => j.JobID == ID));

        [HttpPost]
        public IActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                repository.SaveJob(job);
                TempData["message"] = $"{job.Name} has been saved...{job.JobID}";
                return RedirectToAction("List");
            }
            else
            {
                // there is something wrong with the data values
                return View(job);
            }
        }

        [HttpPost]
        public IActionResult Delete(int ID)
        {
            Job deletedJob = repository.DeleteJob(ID);

            if (deletedJob != null)
            {
                TempData["message"] = $"{deletedJob.Name} was deleted";
            }
            return RedirectToAction("List");
        }

        public ViewResult Add() => View("Edit", new Job());
    }
}
