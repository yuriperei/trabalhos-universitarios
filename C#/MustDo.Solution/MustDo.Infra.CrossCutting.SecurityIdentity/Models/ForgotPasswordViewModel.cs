using System.ComponentModel.DataAnnotations;

namespace MustDo.Infra.CrossCutting.SecurityIdentity.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
