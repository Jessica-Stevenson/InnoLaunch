using Microsoft.EntityFrameworkCore;

namespace InnoLaunch.Models
{
    public class InnoLaunchDbContext : DbContext
    {
        public InnoLaunchDbContext(DbContextOptions<InnoLaunchDbContext> options)
            : base(options) { }


        public DbSet<Startup> Startups { get; set; }
        public DbSet<Founder> Founders { get; set; }  
    }
 }
