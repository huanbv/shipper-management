using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "Vui lòng nhập E-mail")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
    }
}