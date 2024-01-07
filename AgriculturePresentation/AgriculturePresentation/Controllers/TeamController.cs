using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values = _teamService.GetListAll();
            return View(values);
        }
        [HttpGet] 
        public IActionResult AddTeam() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult validationResult = validationRules.Validate(team);
            if(validationResult.IsValid) 
            {
                _teamService.Insert(team);
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
        public IActionResult DeleteTeam(int id) 
        {
            var values = _teamService.GetById(id);
            _teamService.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var values = _teamService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult validationResult = validationRules.Validate(team);
            if (validationResult.IsValid)
            {
                _teamService.Update(team);
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
