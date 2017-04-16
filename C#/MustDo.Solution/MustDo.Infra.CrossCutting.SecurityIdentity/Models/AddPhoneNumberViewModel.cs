using System.ComponentModel.DataAnnotations;

namespace MustDo.Infra.CrossCutting.SecurityIdentity.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}