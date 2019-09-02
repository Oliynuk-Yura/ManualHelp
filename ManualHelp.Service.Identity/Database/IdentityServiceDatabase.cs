using ManualHelp.Service.Identity.Domain.JwtIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Service.Identity.Database
{
    public class IdentityServiceDatabase : IdentityDbContext<User, Role, Guid>
    {
        public IdentityServiceDatabase(DbContextOptions<IdentityServiceDatabase> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
