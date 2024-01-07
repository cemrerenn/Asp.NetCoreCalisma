using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,loginViewModel.password,false,true);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignUp() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)//bizim oluşturduğumuz sınıftaki bilgiler gelecek
        {
            IdentityUser ıdentityUser = new IdentityUser()//Identity kütüphanesi ile eklenen sınıf
            {
                Id="1",
                UserName=registerViewModel.UserName,//Identity kütüphanesi ile model klasöründe bizim oluşturduğumuz sınıftaki bilgileri ekliyoruz.
                Email=registerViewModel.mail,

            };
            if(registerViewModel.password==registerViewModel.Confirmpassword) 
            {
                var result = await _userManager.CreateAsync(ıdentityUser, registerViewModel.password);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(registerViewModel);
        }
    }
}
