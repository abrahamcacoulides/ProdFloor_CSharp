using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using ProdFloor.Models;
using ProdFloor.Models.ViewModels;

namespace ProdFloor.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IJobRepository repository;

        public NavigationMenuViewComponent(IJobRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedJobType = RouteData?.Values["jobType"];
            return View(repository.Jobs
            .Select(x => x.JobType)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
