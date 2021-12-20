﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopApp.Data;

namespace ShopApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopApp.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Food Shop"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Electronics Shop"
                        });
                });

            modelBuilder.Entity("ShopApp.Models.ShopItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExpiryDate = new DateTime(2022, 2, 15, 16, 37, 59, 458, DateTimeKind.Utc).AddTicks(8311),
                            Name = "Banana",
                            ShopId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExpiryDate = new DateTime(2022, 2, 15, 16, 37, 59, 458, DateTimeKind.Utc).AddTicks(9253),
                            Name = "Apple",
                            ShopId = 1
                        },
                        new
                        {
                            Id = 3,
                            ExpiryDate = new DateTime(2022, 2, 15, 16, 37, 59, 458, DateTimeKind.Utc).AddTicks(9257),
                            Name = "Phone",
                            ShopId = 2
                        },
                        new
                        {
                            Id = 4,
                            ExpiryDate = new DateTime(2022, 2, 15, 16, 37, 59, 458, DateTimeKind.Utc).AddTicks(9259),
                            Name = "PC",
                            ShopId = 2
                        },
                        new
                        {
                            Id = 5,
                            ExpiryDate = new DateTime(2022, 2, 15, 16, 37, 59, 458, DateTimeKind.Utc).AddTicks(9260),
                            Name = "TV",
                            ShopId = 2
                        },
                        new
                        {
                            Id = 6,
                            ExpiryDate = new DateTime(2022, 2, 15, 16, 37, 59, 458, DateTimeKind.Utc).AddTicks(9261),
                            Name = "Potato",
                            ShopId = 1
                        });
                });

            modelBuilder.Entity("ShopApp.Models.ShopItem", b =>
                {
                    b.HasOne("ShopApp.Models.Shop", "Shop")
                        .WithMany("ShopItems")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("ShopApp.Models.Shop", b =>
                {
                    b.Navigation("ShopItems");
                });
#pragma warning restore 612, 618
        }
    }
}
