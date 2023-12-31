﻿// <auto-generated />
using System;
using Kitchen.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kitchen.Data.Migrations
{
    [DbContext(typeof(SqlServerApplicationContext))]
    partial class SqlServerApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kitchen.Core.Domain.Food.Food", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Available")
                        .HasMaxLength(100)
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateON")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateON")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Food.FoodPicture", b =>
                {
                    b.Property<int>("FoodID")
                        .HasColumnType("int");

                    b.Property<int>("PictureID")
                        .HasColumnType("int");

                    b.HasKey("FoodID", "PictureID");

                    b.HasIndex("PictureID");

                    b.ToTable("FoodPicture");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Food.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateON")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateON")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Food.GroupFood", b =>
                {
                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("FoodID")
                        .HasColumnType("int");

                    b.HasKey("GroupID", "FoodID");

                    b.HasIndex("FoodID");

                    b.ToTable("GroupFood");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Food.Picture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateON")
                        .HasColumnType("datetime2");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateON")
                        .HasColumnType("datetime2");

                    b.Property<string>("VirtualPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Order.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateON")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateON")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Order.OrderItem", b =>
                {
                    b.Property<int>("Food_Id")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateON")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoodID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateON")
                        .HasColumnType("datetime2");

                    b.HasKey("Food_Id", "OrderId");

                    b.HasIndex("FoodID");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.User.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("ConiformEmail")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateON")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateON")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Food.FoodPicture", b =>
                {
                    b.HasOne("Kitchen.Core.Domain.Food.Food", "Food")
                        .WithMany("FoodPictures")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kitchen.Core.Domain.Food.Picture", "Picture")
                        .WithMany("FoodPictures")
                        .HasForeignKey("PictureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Food.GroupFood", b =>
                {
                    b.HasOne("Kitchen.Core.Domain.Food.Food", "Food")
                        .WithMany("GroupFoods")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kitchen.Core.Domain.Food.Group", "Group")
                        .WithMany("GroupFoods")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Order.Order", b =>
                {
                    b.HasOne("Kitchen.Core.Domain.User.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Order.OrderItem", b =>
                {
                    b.HasOne("Kitchen.Core.Domain.Food.Food", "Food")
                        .WithMany("OrderItems")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kitchen.Core.Domain.Order.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Food.Food", b =>
                {
                    b.Navigation("FoodPictures");

                    b.Navigation("GroupFoods");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Food.Group", b =>
                {
                    b.Navigation("GroupFoods");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Food.Picture", b =>
                {
                    b.Navigation("FoodPictures");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.Order.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Kitchen.Core.Domain.User.User", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
