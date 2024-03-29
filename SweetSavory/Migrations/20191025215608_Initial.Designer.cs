﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SweetSavory.Models;

namespace SweetSavory.Migrations
{
    [DbContext(typeof(SweetSavoryContext))]
    [Migration("20191025215608_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SweetSavory.Models.Flavor", b =>
                {
                    b.Property<int>("FlavorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FlavorName");

                    b.HasKey("FlavorID");

                    b.ToTable("Flavors");
                });

            modelBuilder.Entity("SweetSavory.Models.FlavorTreat", b =>
                {
                    b.Property<int>("FlavorTreatID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FlavorID");

                    b.Property<int?>("TreatID");

                    b.HasKey("FlavorTreatID");

                    b.HasIndex("FlavorID");

                    b.HasIndex("TreatID");

                    b.ToTable("FlavorTreats");
                });

            modelBuilder.Entity("SweetSavory.Models.Treat", b =>
                {
                    b.Property<int>("TreatID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TreatName");

                    b.HasKey("TreatID");

                    b.ToTable("Treats");
                });

            modelBuilder.Entity("SweetSavory.Models.FlavorTreat", b =>
                {
                    b.HasOne("SweetSavory.Models.Flavor", "Flavor")
                        .WithMany("Treats")
                        .HasForeignKey("FlavorID");

                    b.HasOne("SweetSavory.Models.Treat", "Treat")
                        .WithMany("Flavors")
                        .HasForeignKey("TreatID");
                });
#pragma warning restore 612, 618
        }
    }
}
