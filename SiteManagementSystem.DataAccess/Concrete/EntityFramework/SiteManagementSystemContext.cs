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
        public DbSet<Person> People { get; set; }
        public DbSet<PersonNote> PersonNotes { get; set; }
        public DbSet<User> Users { get; set; }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(b => b.Site)
                    .WithMany(p => p.Blocks)
                    .HasForeignKey(b => b.SiteId);
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

                entity.HasOne(f => f.Block)
                    .WithMany(p => p.Flats)
                    .HasForeignKey(f => f.BlockId);

                entity.HasOne(f => f.FlatOwner)
                    .WithMany(p => p.OwnedFlats)
                    .HasForeignKey(f => f.FlatOwnerId);

                entity.HasOne(f => f.Tenant)
                    .WithOne(p => p.TenantsFlat)
                    .HasForeignKey<Flat>(f => f.TenantId);

            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(s => s.District)
                    .WithMany(p => p.Sites)
                    .HasForeignKey(s => s.DistrictId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<PersonNote>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(pn => pn.Person)
                    .WithMany(p => p.PersonNotes)
                    .HasForeignKey(pn => pn.PersonId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(u => u.Site)
                    .WithOne(p => p.SiteManager)
                    .HasForeignKey<Site>(u => u.SiteManagerId);
            });

            DataSeeder.SeedData(modelBuilder);
        }
    }
}
