using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NexUs.Core.Domain.Entities;
using NexUs.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Infrastructure.Identity.Contexts
{
    internal class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Properties
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            #endregion

            #region Relationships
            builder.Entity<ApplicationUser>()
                .HasMany<Post>(a => a.Posts)
                .WithOne()
                .HasForeignKey(p => p.UserId);

            builder.Entity<ApplicationUser>()
                .HasMany<Comment>(a => a.Comments)
                .WithOne()
                .HasForeignKey(c => c.UserId);
            #endregion

        }
    }
}
