using System.Web.Mvc;

namespace MijemApplication.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View("Error");
        }
    }
}