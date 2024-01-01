﻿// <auto-generated />
using CarMvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("CarMvc.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Capacity")
                        .HasColumnType("REAL");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Motor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrgId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Power")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrgId")
                        .IsUnique();

                    b.ToTable("Car");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 1.3999999999999999,
                            Model = "Octavia",
                            Motor = "Benzyna",
                            OrgId = 1,
                            Power = 100,
                            Priority = 3,
                            Producer = "Skoda",
                            RegistrationNumber = "ABC123"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 1.3999999999999999,
                            Model = "A3",
                            Motor = "Benzyna",
                            OrgId = 2,
                            Power = 100,
                            Priority = 3,
                            Producer = "Audi",
                            RegistrationNumber = "DEF456"
                        });
                });

            modelBuilder.Entity("Core.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrgId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrgId")
                        .IsUnique();

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Miasto A",
                            Country = "Kraj A",
                            Number = 1,
                            OrgId = 1,
                            State = "Stan A",
                            Street = "Ulica A"
                        },
                        new
                        {
                            Id = 2,
                            City = "Miasto B",
                            Country = "Kraj B",
                            Number = 2,
                            OrgId = 2,
                            State = "Stan B",
                            Street = "Ulica B"
                        });
                });

            modelBuilder.Entity("Core.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdrId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organization");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdrId = 1,
                            NIP = "1234567890",
                            Name = "Organizacja A"
                        },
                        new
                        {
                            Id = 2,
                            AdrId = 2,
                            NIP = "0987654321",
                            Name = "Organizacja B"
                        });
                });

            modelBuilder.Entity("CarMvc.Models.Car", b =>
                {
                    b.HasOne("Core.Models.Organization", "Owner")
                        .WithOne("car")
                        .HasForeignKey("CarMvc.Models.Car", "OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Core.Models.Address", b =>
                {
                    b.HasOne("Core.Models.Organization", "Organization")
                        .WithOne("Address")
                        .HasForeignKey("Core.Models.Address", "OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Core.Models.Organization", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("car")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}