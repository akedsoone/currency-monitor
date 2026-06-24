using Microsoft.AspNetCore.Mvc;

namespace CurrencyMonitor.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("GetAll", "Department");
        }
    }
}