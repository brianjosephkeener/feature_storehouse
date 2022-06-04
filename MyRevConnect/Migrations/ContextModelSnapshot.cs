﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyRevConnect.Data.Models;

#nullable disable

namespace MyRevConnect.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyRevConnect.Data.Models.Pixel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ipAddress")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("pixels");
                });

            modelBuilder.Entity("MyRevConnect.Data.Models.timedEmail", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("emailAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("emailBody")
                        .HasColumnType("longtext");

                    b.Property<string>("emailHeader")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("emailSent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ipAddress")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("time")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("timedEmails");
                });
#pragma warning restore 612, 618
        }
    }
}
