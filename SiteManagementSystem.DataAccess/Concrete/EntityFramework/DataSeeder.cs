using Microsoft.EntityFrameworkCore;
using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Ankara" },
                new City { Id = 2, Name = "İstanbul" },
                new City { Id = 3, Name = "İzmir" },
                new City { Id = 4, Name = "Konya" }
                );

            modelBuilder.Entity<District>().HasData(
                new District { Id = 1, Name = "Çankaya", CityId = 1 },
                new District { Id = 2, Name = "Keçiören", CityId = 1 },
                new District { Id = 3, Name = "Yenimahalle", CityId = 1 },
                new District { Id = 4, Name = "Kadıköy", CityId = 2 },
                new District { Id = 5, Name = "Beşiktaş", CityId = 2 },
                new District { Id = 6, Name = "Üsküdar", CityId = 2 },
                new District { Id = 7, Name = "Bornova", CityId = 3 },
                new District { Id = 8, Name = "Karşıyaka", CityId = 3 },
                new District { Id = 9, Name = "Konak", CityId = 3 },
                new District { Id = 10, Name = "Selçuklu", CityId = 4 },
                new District { Id = 11, Name = "Meram", CityId = 4 },
                new District { Id = 12, Name = "Karatay", CityId = 4 }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Surname = "Admin", Username = "admin", Password = "admin", IsAdmin = true}
                );
        }
    }
}
