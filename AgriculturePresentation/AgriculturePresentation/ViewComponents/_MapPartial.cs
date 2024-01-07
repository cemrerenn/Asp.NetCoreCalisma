using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _MapPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            AgricultureContext db = new AgricultureContext();
            var values = db.Adresses.Select(x=>x.Mapinfo).FirstOrDefault();
            ViewBag.v = values; 
            return View();
        }
    }
}
