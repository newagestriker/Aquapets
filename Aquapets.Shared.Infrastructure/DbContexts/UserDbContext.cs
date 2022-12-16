using Aquapets.Shared.Domain.Entities;
using Aquapets.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Aquapets.Shared.Infrastructure.DbContexts
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions options):base(options) { }
        
        public DbSet<User>? Users { get; set; }
    }
}
