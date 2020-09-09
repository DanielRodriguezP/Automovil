﻿// <auto-generated />
using System;
using Car.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Car.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Car.Api.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("FirtsName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Document")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Car.Api.Data.Entities.Vehicle", b =>
                {
                    b.Property<string>("LicensePlate")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6);

                    b.Property<string>("Color")
                        .HasMaxLength(12);

                    b.Property<DateTime>("DateAdmission");

                    b.Property<int>("Model");

                    b.Property<Guid>("PhotoId");

                    b.Property<string>("PhotoUrl");

                    b.Property<decimal>("Value");

                    b.HasKey("LicensePlate");

                    b.HasIndex("LicensePlate")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}