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
            if (ModelState.IsValid)
            {
                repository.SaveJob(job);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = new JobExtension { JobID = job.JobID },
                    CurrentHydroSpecific = new HydroSpecific(),
                    CurrentGenericFeatures = new GenericFeatures(),
                    CurrentIndicators = new Indicators(),
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
                    CurrentJobExtension = new JobExtension { JobID = job.JobID },
                    CurrentHydroSpecific = new HydroSpecific(),
                    CurrentGenericFeatures = new GenericFeatures(),
                    CurrentIndicators = new Indicators(),
                };
                return View("create",viewModel);
            }
        }

        [HttpPost]
        public IActionResult NextJobExtension(JobExtension jobExtension)
        {
            if (ModelState.IsValid)
            {
                if(repository.JobsExtensions.FirstOrDefault(j => j.JobID == jobExtension.JobID) == null)
                {
                    repository.SaveJobExtension(jobExtension);
                }
                else
                {
                    repository.SaveJobExtension(repository.JobsExtensions.FirstOrDefault(j => j.JobID == jobExtension.JobID));
                }
                Job job = repository.Jobs.FirstOrDefault(j => j.JobID == jobExtension.JobID);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = jobExtension,
                    CurrentHydroSpecific = new HydroSpecific { JobID = job.JobID },
                    CurrentGenericFeatures = new GenericFeatures(),
                    CurrentIndicators = new Indicators(),
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
        public IActionResult NextHydroSpecific(HydroSpecific hydroSpecific)
        {
            if (ModelState.IsValid)
            {
                if (repository.HydroSpecifics.FirstOrDefault(j => j.JobID == hydroSpecific.JobID) == null)
                {
                    repository.SaveHydroSpecific(hydroSpecific);
                }
                else
                {
                    repository.SaveHydroSpecific(repository.HydroSpecifics.FirstOrDefault(j => j.JobID == hydroSpecific.JobID));
                }
                Job job = repository.Jobs.FirstOrDefault(j => j.JobID == hydroSpecific.JobID);
                JobExtension jobExtension = repository.JobsExtensions.FirstOrDefault(j => j.JobID == hydroSpecific.JobID);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = jobExtension,
                    CurrentHydroSpecific = hydroSpecific,
                    CurrentGenericFeatures = new GenericFeatures { JobID = job.JobID },
                    CurrentIndicators = new Indicators(),
                    CurrentTab = "GenericFeatures"
                };
                TempData["message"] = $"{hydroSpecific.HydroSpecificID} has been saved...{hydroSpecific.JobID}";
                return View("Create", viewModel);
            }
            else
            {
                // there is something wrong with the data values
                Job job = repository.Jobs.FirstOrDefault(j => j.JobID == hydroSpecific.JobID);
                JobExtension jobExtension = repository.JobsExtensions.FirstOrDefault(j => j.JobID == hydroSpecific.JobID);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = jobExtension,
                    CurrentHydroSpecific = hydroSpecific,
                    CurrentTab = "HydroSpecifics"
                };
                return View("Create", viewModel);
            }
        }

        [HttpPost]
        public IActionResult NextGenericFeatures(GenericFeatures genericFeatures)
        {
            if (ModelState.IsValid)
            {
                if (repository.GenericFeaturesList.FirstOrDefault(j => j.JobID == genericFeatures.JobID) == null)
                {
                    repository.SaveGenericFeatures(genericFeatures);
                }
                else
                {
                    repository.SaveGenericFeatures(repository.GenericFeaturesList.FirstOrDefault(j => j.JobID == genericFeatures.JobID));
                }
                Job job = repository.Jobs.FirstOrDefault(j => j.JobID == genericFeatures.JobID);
                JobExtension jobExtension = repository.JobsExtensions.FirstOrDefault(j => j.JobID == genericFeatures.JobID);
                HydroSpecific hydroSpecific = repository.HydroSpecifics.FirstOrDefault(j => j.JobID == genericFeatures.JobID);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = jobExtension,
                    CurrentHydroSpecific = hydroSpecific,
                    CurrentGenericFeatures = genericFeatures,
                    CurrentIndicators = new Indicators { JobID = job.JobID },
                    CurrentTab = "Indicators"
                };
                TempData["message"] = $"{genericFeatures.GenericFeaturesID} has been saved...{genericFeatures.JobID}";
                return View("Create", viewModel);
            }
            else
            {
                // there is something wrong with the data values
                Job job = repository.Jobs.FirstOrDefault(j => j.JobID == genericFeatures.JobID);
                JobExtension jobExtension = repository.JobsExtensions.FirstOrDefault(j => j.JobID == genericFeatures.JobID);
                HydroSpecific hydroSpecific = repository.HydroSpecifics.FirstOrDefault(j => j.JobID == genericFeatures.JobID);
                JobViewModel viewModel = new JobViewModel
                {
                    CurrentJob = job,
                    CurrentJobExtension = jobExtension,
                    CurrentHydroSpecific = hydroSpecific,
                    CurrentGenericFeatures = genericFeatures,
                    CurrentTab = "GenericFeatures"
                };
                return View("Create", viewModel);
            }
        }


        [HttpPost] // TODO not longer needed?????
        public IActionResult Create(JobExtension jobExtension)
        {
            if (ModelState.IsValid)
            {
                JobExtension jobextension = repository.JobsExtensions.FirstOrDefault(j => j.JobID == jobExtension.JobID);
                repository.SaveJobExtension(jobextension);
                Job job = repository.Jobs.FirstOrDefault(j => j.JobID == jobextension.JobID);
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
            Job job = repository.Jobs.FirstOrDefault(j => j.JobID == ID);
            if(job == null)
            {
                ViewBag.Error = "ID doesn't exist";
                return View("Error");
            }
            else
            {
                JobViewModel viewModel = new JobViewModel();
                viewModel.CurrentJob = job;
                if (repository.JobsExtensions.FirstOrDefault(j => j.JobID == ID) != null)
                {
                    viewModel.CurrentJobExtension = repository.JobsExtensions.FirstOrDefault(j => j.JobID == ID);
                    if (repository.HydroSpecifics.FirstOrDefault(j => j.JobID == ID) != null)
                    {
                        viewModel.CurrentHydroSpecific = repository.HydroSpecifics.FirstOrDefault(j => j.JobID == ID);
                        if (repository.GenericFeaturesList.FirstOrDefault(j => j.JobID == ID) != null)
                        {
                            viewModel.CurrentGenericFeatures = repository.GenericFeaturesList.FirstOrDefault(j => j.JobID == ID);
                            viewModel.CurrentIndicators = new Indicators
                            {
                                JobID = job.JobID
                            };
                            viewModel.CurrentTab = "GenericFeatures";
                        }
                        else
                        {
                            viewModel.CurrentGenericFeatures = new GenericFeatures
                            {
                                JobID = viewModel.CurrentJob.JobID
                            };
                            viewModel.CurrentIndicators = new Indicators
                            {
                                JobID = job.JobID
                            };
                            viewModel.CurrentTab = "HydroSpecifics";
                        }
                    }
                    else
                    {
                        viewModel.CurrentHydroSpecific = new HydroSpecific
                        {
                            JobID = viewModel.CurrentJob.JobID
                        };
                        viewModel.CurrentGenericFeatures = new GenericFeatures
                        {
                            JobID = viewModel.CurrentJob.JobID
                        };
                        viewModel.CurrentIndicators = new Indicators
                        {
                            JobID = job.JobID
                        };
                        viewModel.CurrentTab = "Extension";
                    }
                }
                else
                {
                    viewModel.CurrentJobExtension = new JobExtension
                    {
                        JobID = job.JobID
                    };
                    viewModel.CurrentHydroSpecific = new HydroSpecific
                    {
                        JobID = job.JobID
                    };
                    viewModel.CurrentGenericFeatures = new GenericFeatures
                    {
                        JobID = job.JobID
                    };
                    viewModel.CurrentIndicators = new Indicators
                    {
                        JobID = job.JobID
                    };
                    viewModel.CurrentTab = "Main";
                }
                return View(viewModel);
            }
            
        }
    }
}
