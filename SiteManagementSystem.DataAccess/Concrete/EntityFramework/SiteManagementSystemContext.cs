using Microsoft.EntityFrameworkCore;
using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace SiteManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class SiteManagementSystemContext : DbContext
    {
        public SiteManagementSystemContext()
        {
        }
        public SiteManagementSystemContext(DbContextOptions<SiteManagementSystemContext> options) : base(options)
        {
        }

        public DbSet<Block> Blocks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Site> Sites { get; set; }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Blocks)
                    .HasForeignKey(d => d.SiteId);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.CityId);
            });

            modelBuilder.Entity<Flat>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Flats)
                    .HasForeignKey(d => d.BlockId);
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Sites)
                    .HasForeignKey(d => d.DistrictId);
            });

            DataSeeder.SeedData(modelBuilder);
        }
    }
}
