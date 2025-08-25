using InnoLaunch.Models;

namespace InnoLaunch.Data
{
    public class SeedData
    {
        public static void Initialize(InnoLaunchDbContext context)
        {
            if (!context.Founders.Any())
            {
                context.Founders.AddRange(
                    new Founder { Name = "Alice Smith" },
                    new Founder { Name = "Bob Johnson" },
                    new Founder { Name = "Charlie Brown" }
                );
                context.SaveChanges();

                if (!context.Startups.Any())
                {
                    context.Startups.AddRange(
                        new Startup { Name = "GreenFlow Tech", Industry = "Clean Energy", HeadquartersLocation = "Wellington", DateFounded = new DateTime(2019, 5, 1), EmployeeCount = 24, FounderId = 1 },
                        new Startup { Name = "CodeNest", Industry = "Software Development", HeadquartersLocation = "Auckland", DateFounded = new DateTime(2021, 3, 1), EmployeeCount = 15, FounderId = 2 },
                        new Startup { Name = "MediChain", Industry = "Health Tech", HeadquartersLocation = "Christchurch", DateFounded = new DateTime(2018, 11, 1), EmployeeCount = 42, FounderId = 1 }
                    );
                    context.SaveChanges();
                }
            //    if (!context.Startups.Any())
            //{
            //    context.Startups.AddRange(
            //        new Startup { Name = "GreenFlow Tech", Industry = "Energy", HeadquartersLocation = "Wellington", DateFounded = new DateTime(2019, 5, 1), EmployeeCount = 24, FounderId = 1 },
            //        new Startup { Name = "CodeNest", Industry = "Software", HeadquartersLocation = "Auckland", DateFounded = new DateTime(2021, 3, 1), EmployeeCount = 15, FounderId = 2 },
            //        new Startup { Name = "MediChain", Industry = "Health", HeadquartersLocation = "Wellington", DateFounded = new DateTime(2018, 11, 1), EmployeeCount = 42 , FounderId = 3 }
            //    );
            //    context.SaveChanges();
            }
        }
    }
}
