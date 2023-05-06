using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Data
{
    //public class DbContextClass : IdentityDbContext<ApplicationUser>
    //{
    //    public DbContextClass(DbContextOptions<DbContextClass> options): base(options)
    //    {

    //    }
    //    protected readonly IConfiguration Configuration;

    //    public DbContextClass(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }
    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    {
    //        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    //    }
    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);
    //    }
    //    public DbSet<User> Users { get; set; }
    //}
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
