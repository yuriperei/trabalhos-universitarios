using System.ComponentModel.DataAnnotations;

namespace MustDo.Infra.CrossCutting.SecurityIdentity.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}