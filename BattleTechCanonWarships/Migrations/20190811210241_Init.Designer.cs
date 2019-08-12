﻿// <auto-generated />
using System;
using BattleTechCanonWarships.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BattleTechCanonWarships.Migrations
{
    [DbContext(typeof(WarshipsContext))]
    [Migration("20190811210241_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BattleTechCanonWarships.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.ShipClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Crew");

                    b.Property<string>("Image");

                    b.Property<int>("IntroductionYear");

                    b.Property<int>("Length");

                    b.Property<string>("Name");

                    b.Property<int>("NumberInClass");

                    b.Property<int>("Role");

                    b.Property<int>("Tonnage");

                    b.HasKey("Id");

                    b.ToTable("ShipClasses");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Source", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PageCount");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Vessel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Vessels");
                });
#pragma warning restore 612, 618
        }
    }
}
