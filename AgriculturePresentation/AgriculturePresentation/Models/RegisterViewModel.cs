using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı adını giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen mail giriniz")]
        public string mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("password", ErrorMessage ="Şifreler Uyumlu değil")]
        public string Confirmpassword { get; set; }

       

    }
}
