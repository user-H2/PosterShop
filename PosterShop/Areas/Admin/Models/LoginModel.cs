using System.ComponentModel.DataAnnotations;

namespace PosterShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời nhập password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}