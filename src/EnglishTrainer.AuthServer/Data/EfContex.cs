using JWTTokensTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTTokensTest.Data
{
    public class EfContex : DbContext
    {
        public EfContex(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
