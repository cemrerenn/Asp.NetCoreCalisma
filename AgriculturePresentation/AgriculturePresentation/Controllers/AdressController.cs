using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AdressController : Controller
    {
        private readonly IAdressService _adressService;

        public AdressController(IAdressService adressService)
        {
            _adressService = adressService;
        }

        public IActionResult Index()
        {
            var values = _adressService.GetListAll();
            return View(values);
        }
       
      
        [HttpGet]
        public IActionResult EditAdress(int id)
        {
            var values = _adressService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAdress(Adress adress)
        {
            AdressValidator validationRules = new AdressValidator();
            ValidationResult validationResult = validationRules.Validate(adress);
            if (validationResult.IsValid)
            {
                _adressService.Update(adress);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
