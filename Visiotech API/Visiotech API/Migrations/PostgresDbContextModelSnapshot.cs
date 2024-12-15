﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Visiotech_API.Data;

#nullable disable

namespace Visiotech_API.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    partial class PostgresDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("vineyards")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Visiotech_API.Models.Entities.GrapeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Grapes", "vineyards");
                });

            modelBuilder.Entity("Visiotech_API.Models.Entities.ManagerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Managers", "vineyards");
                });

            modelBuilder.Entity("Visiotech_API.Models.Entities.ParcelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Area")
                        .HasColumnType("double precision");

                    b.Property<Guid>("GrapeEntityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ManagerEntityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VineyardEntityId")
                        .HasColumnType("uuid");

                    b.Property<int>("YearPlanted")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GrapeEntityId");

                    b.HasIndex("ManagerEntityId");

                    b.HasIndex("VineyardEntityId");

                    b.ToTable("Parcels", "vineyards");
                });

            modelBuilder.Entity("Visiotech_API.Models.Entities.VineyardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Vineyards", "vineyards");
                });

            modelBuilder.Entity("Visiotech_API.Models.Entities.ParcelEntity", b =>
                {
                    b.HasOne("Visiotech_API.Models.Entities.GrapeEntity", "Grape")
                        .WithMany()
                        .HasForeignKey("GrapeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Visiotech_API.Models.Entities.ManagerEntity", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Visiotech_API.Models.Entities.VineyardEntity", "Vineyard")
                        .WithMany()
                        .HasForeignKey("VineyardEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grape");

                    b.Navigation("Manager");

                    b.Navigation("Vineyard");
                });
#pragma warning restore 612, 618
        }
    }
}
