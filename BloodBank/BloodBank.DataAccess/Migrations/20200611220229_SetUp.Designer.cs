﻿// <auto-generated />
using System;
using BloodBank.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BloodBank.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200611220229_SetUp")]
    partial class SetUp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BloodBank.Models.BloodDonator", b =>
                {
                    b.Property<int>("Pesel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AmmountOfBloodDonated")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("BloodGroupName")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HomeAdress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.HasKey("Pesel");

                    b.HasIndex("BloodGroupName");

                    b.HasIndex("UserEmail")
                        .IsUnique();

                    b.ToTable("BloodDonators");
                });

            modelBuilder.Entity("BloodBank.Models.BloodStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BloodGroupName")
                        .HasColumnType("text");

                    b.Property<int>("StoredAmmount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BloodGroupName")
                        .IsUnique();

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("BloodBank.Models.BloodType", b =>
                {
                    b.Property<string>("BloodGroupName")
                        .HasColumnType("text");

                    b.HasKey("BloodGroupName");

                    b.ToTable("BloodTypes");
                });

            modelBuilder.Entity("BloodBank.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsBloodDonator")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsWorker")
                        .HasColumnType("boolean");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserEmail")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BloodBank.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BloodBank.Models.BloodDonator", b =>
                {
                    b.HasOne("BloodBank.Models.BloodType", "BloodType")
                        .WithMany()
                        .HasForeignKey("BloodGroupName");

                    b.HasOne("BloodBank.Models.User", "User")
                        .WithOne("BloodDonator")
                        .HasForeignKey("BloodBank.Models.BloodDonator", "UserEmail");
                });

            modelBuilder.Entity("BloodBank.Models.BloodStorage", b =>
                {
                    b.HasOne("BloodBank.Models.BloodType", "BloodType")
                        .WithOne("BloodStorage")
                        .HasForeignKey("BloodBank.Models.BloodStorage", "BloodGroupName");
                });

            modelBuilder.Entity("BloodBank.Models.Role", b =>
                {
                    b.HasOne("BloodBank.Models.User", "User")
                        .WithOne("Role")
                        .HasForeignKey("BloodBank.Models.Role", "UserEmail");
                });
#pragma warning restore 612, 618
        }
    }
}
