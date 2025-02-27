using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz !")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz !")]
        public string PassWord { get; set; }
    }
}
