﻿// <auto-generated />
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment1.Migrations.Shop
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment1.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "Nike"
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "Adidas"
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = "Puma"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndBid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StartBid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAuhtor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            Code = "nike_mercurial",
                            Condition = "Good",
                            Description = "Shoes",
                            EndBid = "2023/5/15",
                            Name = "Nike Mercurial",
                            Price = 125m,
                            StartBid = "2022/12/1",
                            UserAuhtor = "admin@gmail.com"
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 1,
                            Code = "nike_vapor",
                            Condition = "Good",
                            Description = "Shoes",
                            EndBid = "2023/5/15",
                            Name = "Nike Vapor",
                            Price = 208.85m,
                            StartBid = "2022/12/1",
                            UserAuhtor = "admin@gmail.com"
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 3,
                            Code = "puma_future",
                            Condition = "Good",
                            Description = "Shoes",
                            EndBid = "2023/5/15",
                            Name = "Puma Future",
                            Price = 285m,
                            StartBid = "2022/12/1",
                            UserAuhtor = "admin@gmail.com"
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 3,
                            Code = "puma_court",
                            Condition = "Good",
                            Description = "Shoes",
                            EndBid = "2023/5/15",
                            Name = "Court Rider",
                            Price = 120m,
                            StartBid = "2022/12/1",
                            UserAuhtor = "admin@gmail.com"
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryID = 2,
                            Code = "adidas_ozelia",
                            Condition = "Good",
                            Description = "Shoes",
                            EndBid = "2023/5/15",
                            Name = "Adidas Ozelia",
                            Price = 130m,
                            StartBid = "2022/12/1",
                            UserAuhtor = "admin@gmail.com"
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryID = 2,
                            Code = "adidas_ozweego",
                            Condition = "Good",
                            Description = "Shoes",
                            EndBid = "2023/5/15",
                            Name = "Adidas Ozweego",
                            Price = 170m,
                            StartBid = "2022/12/1",
                            UserAuhtor = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Product", b =>
                {
                    b.HasOne("Assignment1.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
