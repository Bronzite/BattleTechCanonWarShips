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
    [Migration("20190824202512_MakeNumberInClassNullable")]
    partial class MakeNumberInClassNullable
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

                    b.Property<Guid?>("LocationId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentLocationId");

                    b.Property<int?>("X");

                    b.Property<int?>("Y");

                    b.HasKey("Id");

                    b.HasIndex("ParentLocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Reference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("Page");

                    b.Property<string>("Quote");

                    b.Property<Guid?>("SourceId");

                    b.Property<string>("URL");

                    b.Property<DateTime?>("URLCapture");

                    b.Property<string>("ValidatedBy");

                    b.Property<DateTime?>("ValidatedOn");

                    b.Property<Guid?>("VesselEventId");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.HasIndex("VesselEventId");

                    b.ToTable("Reference");
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

                    b.Property<int?>("NumberInClass");

                    b.Property<string>("Role");

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

            modelBuilder.Entity("BattleTechCanonWarships.Models.SourceReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EndPage");

                    b.Property<DateTime>("ReviewDate");

                    b.Property<string>("Reviewer");

                    b.Property<Guid>("SourceId");

                    b.Property<int>("StartPage");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.ToTable("SourceReview");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Vessel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("PreviousVesselId");

                    b.Property<Guid>("ShipClassId");

                    b.HasKey("Id");

                    b.HasIndex("PreviousVesselId");

                    b.HasIndex("ShipClassId");

                    b.ToTable("Vessels");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Vessel+Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Vessel+PropertyChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EventId");

                    b.Property<string>("PreviousValue");

                    b.Property<Guid>("PropertyId");

                    b.Property<string>("Value");

                    b.Property<Guid?>("VesselEventId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("VesselEventId");

                    b.ToTable("PropertyChange");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.VesselEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EventId");

                    b.Property<Guid>("VesselId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("VesselId");

                    b.ToTable("VesselEvent");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Event", b =>
                {
                    b.HasOne("BattleTechCanonWarships.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Location", b =>
                {
                    b.HasOne("BattleTechCanonWarships.Models.Location", "ParentLocation")
                        .WithMany()
                        .HasForeignKey("ParentLocationId");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Reference", b =>
                {
                    b.HasOne("BattleTechCanonWarships.Models.Source", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.HasOne("BattleTechCanonWarships.Models.VesselEvent")
                        .WithMany("References")
                        .HasForeignKey("VesselEventId");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.SourceReview", b =>
                {
                    b.HasOne("BattleTechCanonWarships.Models.Source", "Source")
                        .WithMany("SourceReviews")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Vessel", b =>
                {
                    b.HasOne("BattleTechCanonWarships.Models.Vessel", "PreviousVessel")
                        .WithMany()
                        .HasForeignKey("PreviousVesselId");

                    b.HasOne("BattleTechCanonWarships.Models.ShipClass", "ShipClass")
                        .WithMany()
                        .HasForeignKey("ShipClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.Vessel+PropertyChange", b =>
                {
                    b.HasOne("BattleTechCanonWarships.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BattleTechCanonWarships.Models.Vessel+Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BattleTechCanonWarships.Models.VesselEvent")
                        .WithMany("PropertyChanges")
                        .HasForeignKey("VesselEventId");
                });

            modelBuilder.Entity("BattleTechCanonWarships.Models.VesselEvent", b =>
                {
                    b.HasOne("BattleTechCanonWarships.Models.Event", "Event")
                        .WithMany("Vessels")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BattleTechCanonWarships.Models.Vessel", "Vessel")
                        .WithMany("Events")
                        .HasForeignKey("VesselId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
