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
            #region Tables
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            #endregion

            #region relations
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(p => p.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);
                
            #endregion

            #region Navegation
            modelBuilder.Entity<Post>()
                .Navigation(p => p.Comments)
                .AutoInclude();
            #endregion


        }


    }
}
