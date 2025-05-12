using CaliApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaliApp.Infrastructure.Presistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
    }
}
