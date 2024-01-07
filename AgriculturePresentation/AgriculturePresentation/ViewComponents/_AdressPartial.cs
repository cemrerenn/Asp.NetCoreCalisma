using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _AdressPartial:ViewComponent
    {
        private readonly IAdressService _adressServic;

        public _AdressPartial(IAdressService adressServic)
        {
            _adressServic = adressServic;
        }

        public IViewComponentResult Invoke()
        {
            var values = _adressServic.GetListAll();
            return View(values);
        }
    }
}
