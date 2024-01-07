using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ChartController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductChart() 
        {
            List<ProductClass> productClass = new List<ProductClass>();
            productClass.Add(new ProductClass
            {
                productname="Buğday",
                productvalue=850
            });
            productClass.Add(new ProductClass
            {
                productname = "Mercimek",
                productvalue = 480
            });
            productClass.Add(new ProductClass
            {
                productname = "Arpa",
                productvalue = 250
            });
            productClass.Add(new ProductClass
            {
                productname = "Pirinç",
                productvalue = 120
            });
            productClass.Add(new ProductClass
            {
                productname = "Domatse",
                productvalue = 960
            });
            return Json(new { jsonlist = productClass });
        }
    }
}
