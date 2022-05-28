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

            modelBuilder.Entity("MyRevConnect.Data.Models.Clock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("emailAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("emailBody")
                        .HasColumnType("longtext");

                    b.Property<string>("emailHeader")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ipAddress")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Clocks");
                });
#pragma warning restore 612, 618
        }
    }
}