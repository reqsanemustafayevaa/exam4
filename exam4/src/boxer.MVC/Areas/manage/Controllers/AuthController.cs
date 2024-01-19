using boxer.business.Exceptions;
using boxer.business.Services.Interfaces;
using boxer.business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace boxer.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if(!ModelState.IsValid)
            {
                return View(loginView);
            }
            try
            {
                await _authService.Login(loginView);
            }
            catch(InvalidCredsException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(loginView);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(loginView);
            }
            return RedirectToAction("index","student"); 
        }
    }
}
