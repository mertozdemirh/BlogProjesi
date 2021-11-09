using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjesi.Models.ViewModels.Auth.Login
{
    public class LoginViewModel
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z0-9.-]{8,}$", ErrorMessage = "Şifre minimum 8 karakter olmalıdır")]
        public string Password { get; set; }
    }
}
