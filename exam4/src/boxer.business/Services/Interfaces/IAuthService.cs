using boxer.business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxer.business.Services.Interfaces
{
    public interface IAuthService
    {
        Task Login(LoginViewModel loginView);
       
    }
}
