using InnoLaunch.Models;

namespace InnoLaunch.Data
{
    public class SeedData
    {
        public static void Initialize(InnoLaunchDbContext context)
        {
            if (!context.Startups.Any())
            {
                context.Startups.AddRange(
                    new Startup { Name = "GreenFlow Tech", Industry = "Energy", HeadquartersLocation = "Wellington", DateFounded = new DateTime(2019, 5, 1), EmployeeCount = 24 },
                    new Startup { Name = "CodeNest", Industry = "Software", HeadquartersLocation = "Auckland", DateFounded = new DateTime(2021, 3, 1), EmployeeCount = 15 },
                    new Startup { Name = "GreenFlow Tech", Industry = "Energy", HeadquartersLocation = "Wellington", DateFounded = new DateTime(2019, 5, 1), EmployeeCount = 24 }
                );
                context.SaveChanges();
            }
        }
    }
}
