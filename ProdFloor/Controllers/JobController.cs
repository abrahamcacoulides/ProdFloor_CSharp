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
        private IItemRepository itemsrepository;
        public int PageSize = 4;

        public JobController(IJobRepository repo,IItemRepository itemsrepo)
        {
            repository = repo;
            itemsrepository = itemsrepo;
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

        public ViewResult Edit(int ID)
        {
            ViewData["JobTypes"] = itemsrepository.JobTypes;
            return View(repository.Jobs
                .FirstOrDefault(j => j.JobID == ID));
        }

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
                ViewData["JobTypes"] = itemsrepository.JobTypes;
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

        [HttpPost]
        public IActionResult NextJob(Job job)
        {
            ViewData["JobTypes"] = itemsrepository.JobTypes;
            ViewData["DoorOperators"] = itemsrepository.DoorOperators;
            ViewData["FireCodes"] = itemsrepository.FireCodes;
            ViewData["Countries"] = itemsrepository.Countries;
            ViewData["States"] = itemsrepository.States;
            ViewData["Cities"] = itemsrepository.Cities;

            if (ModelState.IsValid)
            {
                repository.SaveJob(job);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = new JobExtension { JobID = job.JobID },
                    CurrentTab = "Extension"
                };
                return View("create",viewModel);
            }
            else
            {
                // there is something wrong with the data values
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                };
                return View("create",viewModel);
            }
        }

        [HttpPost]
        public IActionResult NextJobExtension(JobExtension jobExtension)
        {
            ViewData["JobTypes"] = itemsrepository.JobTypes;
            ViewData["DoorOperators"] = itemsrepository.DoorOperators;
            ViewData["FireCodes"] = itemsrepository.FireCodes;
            ViewData["Countries"] = itemsrepository.Countries;
            ViewData["States"] = itemsrepository.States;
            ViewData["Cities"] = itemsrepository.Cities;
            if (ModelState.IsValid)
            {
                repository.SaveJobExtension(jobExtension);
                Job job = repository.Jobs.FirstOrDefault(j => j.JobID == jobExtension.JobID);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = jobExtension,
                    CurrentHydroSpecifics = new HydroSpecifics { JobID = job.JobID },
                    CurrentTab = "HydroSpecifics"
                };
                TempData["message"] = $"{jobExtension.JobExtensionID} has been saved...{jobExtension.JobID}";
                return View("Create",viewModel);
            }
            else
            {
                // there is something wrong with the data values
                Job job = repository.Jobs.FirstOrDefault(j => j.JobID == jobExtension.JobID);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = jobExtension,
                    CurrentTab = "Extension"
                };
                return View("Create", viewModel);
            }
        }

        [HttpPost]
        public IActionResult Create(JobExtension jobExtension)
        {
            ViewData["JobTypes"] = itemsrepository.JobTypes;
            ViewData["DoorOperators"] = itemsrepository.DoorOperators;
            ViewData["FireCodes"] = itemsrepository.FireCodes;
            ViewData["Countries"] = itemsrepository.Countries;
            ViewData["States"] = itemsrepository.States;
            ViewData["Cities"] = itemsrepository.Cities;
            if (ModelState.IsValid)
            {
                repository.SaveJobExtension(jobExtension);
                Job job = repository.Jobs.FirstOrDefault(j => j.JobID == jobExtension.JobID);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = jobExtension,
                    CurrentTab = "Extension"
                };
                TempData["message"] = $"{jobExtension.JobExtensionID} has been saved...{jobExtension.JobID}";
                return View(viewModel);
            }
            else
            {
                // there is something wrong with the data values
                Job job = repository.Jobs.FirstOrDefault(j => j.JobID == jobExtension.JobID);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = jobExtension,
                    CurrentTab = "Extension"
                };
                return View(viewModel);
            }
        }

        public ViewResult JobExtensions() => View(repository.JobsExtensions);

        public ViewResult Create(int ID)
        {
            JobViewModel viewModel = new JobViewModel();
            ViewData["DoorOperators"] = itemsrepository.DoorOperators;
            ViewData["FireCodes"] = itemsrepository.FireCodes;
            ViewData["JobTypes"] = itemsrepository.JobTypes;
            ViewData["Countries"] = itemsrepository.Countries;
            ViewData["States"] = itemsrepository.States;
            ViewData["Cities"] = itemsrepository.Cities;
            viewModel.CurrentJob = repository.Jobs.FirstOrDefault(j => j.JobID == ID);
            if(repository.JobsExtensions.FirstOrDefault(j => j.JobID == ID) != null)
            {
                viewModel.CurrentJobExtension = repository.JobsExtensions.FirstOrDefault(j => j.JobID == ID);
                viewModel.CurrentTab = "Extension";
            }
            else
            {
                viewModel.CurrentJobExtension = new JobExtension {
                    JobID = viewModel.CurrentJob.JobID};
                viewModel.CurrentTab = "Main";
            }
            return View(viewModel);
        }
    }
}
