﻿// <auto-generated />
using System;
using ManageHotels.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManageHotels.Migrations
{
    [DbContext(typeof(HotelsContext))]
    partial class HotelsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RegistrationAndLogin.Model.Hotels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Hotel Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Amenties")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Amenties");

                    b.Property<string>("HotelName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Hotel Name");

                    b.Property<string>("LocationCity")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City Location");

                    b.Property<string>("LocationCountry")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Country Loacation");

                    b.Property<float?>("Price")
                        .HasColumnType("real")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });
#pragma warning restore 612, 618
        }
    }
}