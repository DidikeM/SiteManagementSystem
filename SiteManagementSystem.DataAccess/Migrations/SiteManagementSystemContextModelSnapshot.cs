﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteManagementSystem.DataAccess.Concrete.EntityFramework;

#nullable disable

namespace SiteManagementSystem.DataAccess.Migrations
{
    [DbContext(typeof(SiteManagementSystemContext))]
    partial class SiteManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BlockName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ankara"
                        },
                        new
                        {
                            Id = 2,
                            Name = "İstanbul"
                        },
                        new
                        {
                            Id = 3,
                            Name = "İzmir"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Konya"
                        });
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Çankaya"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "Keçiören"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            Name = "Yenimahalle"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Name = "Kadıköy"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 2,
                            Name = "Beşiktaş"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 2,
                            Name = "Üsküdar"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 3,
                            Name = "Bornova"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 3,
                            Name = "Karşıyaka"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 3,
                            Name = "Konak"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 4,
                            Name = "Selçuklu"
                        },
                        new
                        {
                            Id = 11,
                            CityId = 4,
                            Name = "Meram"
                        },
                        new
                        {
                            Id = 12,
                            CityId = 4,
                            Name = "Karatay"
                        });
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.Flat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<int>("FlatNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfHeating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.Block", b =>
                {
                    b.HasOne("SiteManagementSystem.Entities.Concrete.Site", "Site")
                        .WithMany("Blocks")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.District", b =>
                {
                    b.HasOne("SiteManagementSystem.Entities.Concrete.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.Flat", b =>
                {
                    b.HasOne("SiteManagementSystem.Entities.Concrete.Block", "Block")
                        .WithMany("Flats")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.Site", b =>
                {
                    b.HasOne("SiteManagementSystem.Entities.Concrete.District", "District")
                        .WithMany("Sites")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.Block", b =>
                {
                    b.Navigation("Flats");
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.District", b =>
                {
                    b.Navigation("Sites");
                });

            modelBuilder.Entity("SiteManagementSystem.Entities.Concrete.Site", b =>
                {
                    b.Navigation("Blocks");
                });
#pragma warning restore 612, 618
        }
    }
}
