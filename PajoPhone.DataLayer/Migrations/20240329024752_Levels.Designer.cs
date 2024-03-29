﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PajoPhone.DataLayer;

#nullable disable

namespace PajoPhone.DataLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240329024752_Levels")]
    partial class Levels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PajoPhone.DataLayer.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("PrentCategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Level = 0,
                            Title = "موبایل"
                        });
                });

            modelBuilder.Entity("PajoPhone.DataLayer.Models.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("PajoPhone.DataLayer.Models.FieldProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.ToTable("FieldProducts");
                });

            modelBuilder.Entity("PajoPhone.Datalayer.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageProduct")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ProductColor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ImageProduct = "p1.jpg",
                            ProductColor = "مشکی",
                            ProductName = "محصول 1",
                            ProductPrice = 12000000m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            ImageProduct = "p1.jpg",
                            ProductColor = "سفید",
                            ProductName = "محصول 2",
                            ProductPrice = 5000000m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            ImageProduct = "p1.jpg",
                            ProductColor = "مشکی",
                            ProductName = "محصول 3",
                            ProductPrice = 20000000m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            ImageProduct = "p1.jpg",
                            ProductColor = "مشکی",
                            ProductName = "محصول 4",
                            ProductPrice = 500000m
                        });
                });

            modelBuilder.Entity("PajoPhone.DataLayer.Models.Field", b =>
                {
                    b.HasOne("PajoPhone.DataLayer.Models.Category", "Category")
                        .WithMany("Fields")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PajoPhone.DataLayer.Models.FieldProduct", b =>
                {
                    b.HasOne("PajoPhone.DataLayer.Models.Field", "Field")
                        .WithMany("Products")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PajoPhone.Datalayer.Models.Product", "Product")
                        .WithMany("Fields")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PajoPhone.Datalayer.Models.Product", b =>
                {
                    b.HasOne("PajoPhone.DataLayer.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PajoPhone.DataLayer.Models.Category", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("PajoPhone.DataLayer.Models.Field", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PajoPhone.Datalayer.Models.Product", b =>
                {
                    b.Navigation("Fields");
                });
#pragma warning restore 612, 618
        }
    }
}
