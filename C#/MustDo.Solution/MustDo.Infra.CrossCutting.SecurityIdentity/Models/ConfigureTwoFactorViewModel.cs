using System.Collections.Generic;

namespace MustDo.Infra.CrossCutting.SecurityIdentity.Models
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<string> Providers { get; set; }
    }
}