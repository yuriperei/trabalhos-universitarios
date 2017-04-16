using System;
using MustDo.Infra.CrossCutting.SecurityIdentity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MustDo.Infra.CrossCutting.SecurityIdentity.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}