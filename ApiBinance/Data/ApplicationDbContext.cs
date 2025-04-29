using Microsoft.EntityFrameworkCore;
using ApiBinance.Models;
using System.Collections.Generic;

namespace ApiBinance.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
