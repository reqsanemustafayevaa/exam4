using boxer.business.Exceptions;
using boxer.business.Services.Interfaces;
using boxer.business.ViewModels;
using boxer.core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxer.business.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task Login(LoginViewModel loginView)
        {
            AppUser admin = null;
            admin=await _userManager.FindByNameAsync(loginView.UserName);
            if (admin == null)
            {
               throw new InvalidCredsException("","Username or password incorrect!");
            }
            var result=await _signInManager.PasswordSignInAsync(admin, loginView.Password,false,false);
            if (!result.Succeeded)
            {
                throw new InvalidCredsException("", "Username or password incorrect!");
            }

        }
    }
}
