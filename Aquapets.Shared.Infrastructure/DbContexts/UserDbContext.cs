using Aquapets.Shared.Domain.Consts;
using Aquapets.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquapets.Shared.Infrastructure.DbContexts
{
    public sealed class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions options):base(options) { }
        
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("User");
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
    
    public class UserEntityTypeConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(u => u.Role).HasConversion(l => l!.ToString(), l => new Domain.ValueObjects.UserRole(l))
                .HasColumnName("Role");
       
        }
    }
}
