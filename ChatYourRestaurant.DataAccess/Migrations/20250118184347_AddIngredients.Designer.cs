﻿// <auto-generated />
using System;
using ChatYourRestaurant.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatYourRestaurant.DataAccess.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20250118184347_AddIngredients")]
    partial class AddIngredients
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("ChatYourRestaurant.Domain.Common.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("ChatYourRestaurant.Domain.Common.Models.IngredientMeal", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MealId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IngredientId", "MealId");

                    b.HasIndex("MealId");

                    b.ToTable("IngredientMeal", (string)null);
                });

            modelBuilder.Entity("ChatYourRestaurant.Domain.Common.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("ChatYourRestaurant.Domain.Common.Models.MealQuantity", b =>
                {
                    b.Property<int>("MealId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("MealId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("MealQuantity");
                });

            modelBuilder.Entity("ChatYourRestaurant.Domain.Common.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ChatYourRestaurant.Domain.Common.Models.IngredientMeal", b =>
                {
                    b.HasOne("ChatYourRestaurant.Domain.Common.Models.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatYourRestaurant.Domain.Common.Models.Meal", null)
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatYourRestaurant.Domain.Common.Models.MealQuantity", b =>
                {
                    b.HasOne("ChatYourRestaurant.Domain.Common.Models.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ChatYourRestaurant.Domain.Common.Models.Order", "Order")
                        .WithMany("MealQuantities")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Meal");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ChatYourRestaurant.Domain.Common.Models.Order", b =>
                {
                    b.Navigation("MealQuantities");
                });
#pragma warning restore 612, 618
        }
    }
}
