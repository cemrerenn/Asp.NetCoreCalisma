using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
