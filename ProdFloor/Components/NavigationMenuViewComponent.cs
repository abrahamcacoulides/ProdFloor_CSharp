using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ProdFloor.Models;

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
