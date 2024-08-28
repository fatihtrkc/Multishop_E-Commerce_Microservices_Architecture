﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Multishop.Discount.Data.Context;

#nullable disable

namespace Multishop.Discount.Migrations
{
    [DbContext(typeof(DiscountContext))]
    partial class DiscountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Multishop.Discount.Data.Entities.Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 8, 27, 15, 45, 16, 646, DateTimeKind.Local).AddTicks(7046));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Coupons", t =>
                        {
                            t.HasCheckConstraint("CouponExpirationDateConstraint", "ExpirationDate > GetDate()");

                            t.HasCheckConstraint("CouponMaxRateConstraint", "Rate <= 100");

                            t.HasCheckConstraint("CouponMinCodeLengthConstraint", "Len(Code) > 0");

                            t.HasCheckConstraint("CouponMinRateConstraint", "Rate > 0");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
