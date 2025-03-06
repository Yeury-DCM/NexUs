using Microsoft.EntityFrameworkCore;
using NexUs.Core.Domain.Entities;
using NexUs.Infrastructure.Identity.Entities;


namespace NexUs.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }

        #region Entities
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Post>()
            //    .HasOne<ApplicationUser>()
            //    .WithMany(a => a.Posts)
            //    .HasForeignKey(p => p.UserId);
                
        }
    }
}
