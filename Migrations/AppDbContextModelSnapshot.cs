﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TripApi.Database;

#nullable disable

namespace TripApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TripApi.Models.TouristRoute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DepartureTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<double?>("DiscountPresent")
                        .HasColumnType("double precision");

                    b.Property<string>("Features")
                        .HasColumnType("text");

                    b.Property<string>("Fees")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("TouristRoutes");
                });

            modelBuilder.Entity("TripApi.Models.TouristRoutePicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("TouristRouteId")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("TouristRouteId");

                    b.ToTable("TouristRoutePictures");
                });

            modelBuilder.Entity("TripApi.Models.TouristRoutePicture", b =>
                {
                    b.HasOne("TripApi.Models.TouristRoute", "TouristRoute")
                        .WithMany("TouristRoutePictures")
                        .HasForeignKey("TouristRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TouristRoute");
                });

            modelBuilder.Entity("TripApi.Models.TouristRoute", b =>
                {
                    b.Navigation("TouristRoutePictures");
                });
#pragma warning restore 612, 618
        }
    }
}
