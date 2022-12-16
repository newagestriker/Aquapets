using Aquapets.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquapets.Shared.Infrastructure.DbContexts
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions options):base(options) { }
        
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }

    }
    
    public class UserEntityTypeConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> orderConfiguration)
        {
           
            orderConfiguration.OwnsOne(o => o.Role).Property(r => r.role).HasColumnName("UserRole");
       
        }
    }
}
