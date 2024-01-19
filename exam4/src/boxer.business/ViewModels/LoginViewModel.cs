using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxer.business.ViewModels
{
    public class LoginViewModel
    {
        public string UserName {  get; set; }
        [DataType(DataType.Password)]
        [StringLength(maximumLength:25,MinimumLength =8)]
       
        public string Password { get; set; }
    }
}
