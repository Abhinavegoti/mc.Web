using Microsoft.AspNetCore.Mvc;
using mc.Web.Controllers;

namespace mc.Web.Public.Controllers
{
    public class HomeController : mcControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}