using ProdFloor.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProdFloor.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ViewResult Index() => View();
    }
}
