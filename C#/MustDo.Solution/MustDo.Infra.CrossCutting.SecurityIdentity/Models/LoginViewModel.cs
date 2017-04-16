using System.ComponentModel.DataAnnotations;

namespace MustDo.Infra.CrossCutting.SecurityIdentity.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembre-se de mim?")]
        public bool RememberMe { get; set; }
    }
}