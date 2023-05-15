using System.ComponentModel.DataAnnotations;

namespace RecruiterWeb.Modelos.ViewModels
{
    public class AuthApi
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
