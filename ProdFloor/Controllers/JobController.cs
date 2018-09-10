﻿using Microsoft.AspNetCore.Mvc;
using ProdFloor.Models;
using ProdFloor.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ProdFloor.Controllers
{
    [Authorize(Roles = "Admin,Engineer")]
    public class JobController : Controller
    {
        private IJobRepository repository;
        private IItemRepository itemsrepository;
        private UserManager<AppUser> userManager;
        public int PageSize = 4;

        public JobController(IJobRepository repo,IItemRepository itemsrepo, UserManager<AppUser> userMgr)
        {
            repository = repo;
            itemsrepository = itemsrepo;
            userManager = userMgr;
        }
        
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

        [HttpPost]
        public IActionResult Delete(int ID)
        {
            Job deletedJob = repository.DeleteEngJob(ID);
            if (deletedJob != null)
            {
                TempData["message"] = $"{deletedJob.Name} was deleted";
            }
            else
            {
                TempData["alert"] = $"alert-danger";
                TempData["message"] = $"There was an error with your request";
            }
            return RedirectToAction("List");
        }

        public ViewResult NewJob() => View(new Job());

        [HttpPost]
        public IActionResult NewJob(Job newJob)
        {
            AppUser currentUser = GetCurrentUser().Result;
            if (ModelState.IsValid)
            {
                newJob.EngID = currentUser.EngID;
                newJob.Status = "Incomplete";
                repository.SaveJob(newJob);
                JobViewModel newJobViewModel = new JobViewModel
                {
                    CurrentJob = newJob,
                    CurrentJobExtension = new JobExtension { JobID = newJob.JobID },
                    CurrentHydroSpecific = new HydroSpecific(),
                    CurrentGenericFeatures = new GenericFeatures (),
                    CurrentIndicator = new Indicator (),
                    CurrentHoistWayData = new HoistWayData (),
                    CurrentTab = "Extension"
                };
                TempData["message"] = $"Job# {newJobViewModel.CurrentJob.JobNum} has been saved...{newJobViewModel.CurrentJob.JobID}...{currentUser.EngID}";
                return View("NextForm", newJobViewModel);
            }
            else
            {
                TempData["message"] = $"There seems to be errors in the form. Please validate....{currentUser.EngID}";
                TempData["alert"] = $"alert-danger";
                return View(newJob);
            }
        }
        
        public IActionResult Edit(int ID)
        {
            Job job = repository.Jobs.FirstOrDefault(j => j.JobID == ID);
            if (job == null)
            {
                TempData["message"] = $"The requested Job doesn't exist.";
                return RedirectToAction("List");
            }
            else
            {
                JobViewModel viewModel = new JobViewModel();
                viewModel.CurrentJob = job;
                viewModel.CurrentJobExtension = repository.JobsExtensions.FirstOrDefault(j => j.JobID == ID);
                viewModel.CurrentHydroSpecific = repository.HydroSpecifics.FirstOrDefault(j => j.JobID == ID);
                viewModel.CurrentGenericFeatures = repository.GenericFeaturesList.FirstOrDefault(j => j.JobID == ID);
                viewModel.CurrentIndicator = repository.Indicators.FirstOrDefault(j => j.JobID == ID);
                viewModel.CurrentHoistWayData = repository.HoistWayDatas.FirstOrDefault(j => j.JobID == ID);
                viewModel.CurrentTab = "Main";
                return View(viewModel);
            }

        }

        [HttpPost]
        public IActionResult Edit(JobViewModel multiEditViewModel)
        {
            if (ModelState.IsValid)
            {
                if(multiEditViewModel.CurrentJob.Status == "" || multiEditViewModel.CurrentJob.Status == null)
                {
                    multiEditViewModel.CurrentJob.Status = "Working on it";
                }
                repository.SaveEngJobView(multiEditViewModel);
                multiEditViewModel.CurrentTab = "Main";
                TempData["message"] = $"{multiEditViewModel.CurrentJob.JobNum} ID has been saved...{multiEditViewModel.CurrentJob.JobID}";
                return View(multiEditViewModel);
            }
            else
            {
                // there is something wrong with the data values
                TempData["message"] = $"There seems to be errors in the form. Please validate.";
                TempData["alert"] = $"alert-danger";
                return View(multiEditViewModel);
            }
        }

        public IActionResult Continue(int ID)
        {
            if(repository.Jobs.FirstOrDefault(j => j.JobID == ID) != null)
            {
                JobViewModel continueJobViewModel = new JobViewModel();
                continueJobViewModel.CurrentJob = repository.Jobs.FirstOrDefault(j => j.JobID == ID);
                continueJobViewModel.CurrentJobExtension = (repository.JobsExtensions.FirstOrDefault(j => j.JobID == ID) ?? new JobExtension());
                continueJobViewModel.CurrentHydroSpecific = (repository.HydroSpecifics.FirstOrDefault(j => j.JobID == ID) ?? new HydroSpecific());
                continueJobViewModel.CurrentGenericFeatures = (repository.GenericFeaturesList.FirstOrDefault(j => j.JobID == ID) ?? new GenericFeatures());
                continueJobViewModel.CurrentIndicator = (repository.Indicators.FirstOrDefault(j => j.JobID == ID) ?? new Indicator());
                continueJobViewModel.CurrentHoistWayData = (repository.HoistWayDatas.FirstOrDefault(j => j.JobID == ID) ?? new HoistWayData());
                return View("NextForm", continueJobViewModel);

            }
            else
            {
                TempData["message"] = $"The requested Job Id# {ID} doesn't exist";
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public IActionResult NextForm(JobViewModel nextViewModel)
        {
            if (ModelState.IsValid)
            {
                if(nextViewModel.CurrentJobExtension != null)
                {
                    if (nextViewModel.CurrentHydroSpecific != null)
                    {
                        if (nextViewModel.CurrentGenericFeatures != null)
                        {
                            if (nextViewModel.CurrentIndicator != null)
                            {
                                if (nextViewModel.CurrentHoistWayData != null)
                                {
                                    nextViewModel.CurrentJob.Status = "Working on it";
                                    repository.SaveEngJobView(nextViewModel);
                                    nextViewModel.CurrentTab = "Main";
                                    TempData["message"] = $"everything was saved";
                                    // Here the Job Filling Status should be changed the Working on it
                                    // Redirect to Hub??
                                    return View(nextViewModel);
                                }
                                else
                                {
                                    repository.SaveEngJobView(nextViewModel);
                                    nextViewModel.CurrentHoistWayData = new HoistWayData { JobID = nextViewModel.CurrentJob.JobID };
                                    nextViewModel.CurrentTab = "HoistWayData";
                                    TempData["message"] = $"indicator was saved";
                                    return View(nextViewModel);
                                }
                            }
                            else
                            {
                                repository.SaveEngJobView(nextViewModel);
                                nextViewModel.CurrentIndicator = new Indicator { JobID = nextViewModel.CurrentJob.JobID };
                                nextViewModel.CurrentHoistWayData = new HoistWayData();
                                nextViewModel.CurrentTab = "Indicator";
                                TempData["message"] = $"generic was saved";
                                return View(nextViewModel);
                            }
                        }
                        else
                        {
                            repository.SaveEngJobView(nextViewModel);
                            nextViewModel.CurrentGenericFeatures = new GenericFeatures { JobID = nextViewModel.CurrentJob.JobID };
                            nextViewModel.CurrentIndicator = new Indicator();
                            nextViewModel.CurrentHoistWayData = new HoistWayData();
                            nextViewModel.CurrentTab = "GenericFeatures";
                            TempData["message"] = $"hydro specific was saved";
                            return View(nextViewModel);
                        }
                    }
                    else
                    {
                        repository.SaveEngJobView(nextViewModel);
                        nextViewModel.CurrentHydroSpecific = new HydroSpecific { JobID = nextViewModel.CurrentJob.JobID };
                        nextViewModel.CurrentGenericFeatures = new GenericFeatures();
                        nextViewModel.CurrentIndicator = new Indicator();
                        nextViewModel.CurrentHoistWayData = new HoistWayData();
                        nextViewModel.CurrentTab = "HydroSpecifics";
                        TempData["message"] = $"jobextension was saved";
                        return View(nextViewModel);
                    }
                }
                else
                {
                    repository.SaveEngJobView(nextViewModel);
                    JobExtension jobExt = repository.JobsExtensions.FirstOrDefault(j => j.JobID == nextViewModel.CurrentJob.JobID);
                    nextViewModel.CurrentJobExtension = (jobExt ?? new JobExtension { JobID = nextViewModel.CurrentJob.JobID });
                    nextViewModel.CurrentHydroSpecific = new HydroSpecific ();
                    nextViewModel.CurrentGenericFeatures = new GenericFeatures();
                    nextViewModel.CurrentIndicator = new Indicator();
                    nextViewModel.CurrentHoistWayData = new HoistWayData();
                    nextViewModel.CurrentTab = "Extension";
                    TempData["message"] = $"job was saved";
                    return View(nextViewModel);
                }
            }
            else
            {
                nextViewModel.CurrentHydroSpecific = (nextViewModel.CurrentHydroSpecific ?? new HydroSpecific());
                nextViewModel.CurrentGenericFeatures = (nextViewModel.CurrentGenericFeatures ?? new GenericFeatures());
                nextViewModel.CurrentIndicator = (nextViewModel.CurrentIndicator ?? new Indicator());
                nextViewModel.CurrentHoistWayData = (nextViewModel.CurrentHoistWayData ?? new HoistWayData());
                TempData["message"] = $"nothing was saved";
                return View(nextViewModel);
            }
        }

        private async Task<AppUser> GetCurrentUser()
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);

            return user;
        }
    }
}
