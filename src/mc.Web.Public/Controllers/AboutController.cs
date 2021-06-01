using Microsoft.AspNetCore.Mvc;
using mc.Web.Controllers;

namespace mc.Web.Public.Controllers
{
    public class AboutController : mcControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}