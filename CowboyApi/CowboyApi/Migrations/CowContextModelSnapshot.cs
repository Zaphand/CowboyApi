﻿// <auto-generated />
using System;
using CowboyApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CowboyApi.Migrations
{
    [DbContext(typeof(CowContext))]
    partial class CowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("CowboyApi.Models.Cowboy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("BulletsInGun")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("GunId")
                        .HasColumnType("TEXT");

                    b.Property<int>("HitPoints")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("HorseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalBullets")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GunId");

                    b.HasIndex("HorseId");

                    b.ToTable("Cowboys");
                });

            modelBuilder.Entity("CowboyApi.Models.Gun", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxBullets")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Guns");
                });

            modelBuilder.Entity("CowboyApi.Models.Horse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HitPoints")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("CowboyApi.Models.PassKey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CowboyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PassKeys");
                });

            modelBuilder.Entity("CowboyApi.Models.Cowboy", b =>
                {
                    b.HasOne("CowboyApi.Models.Gun", "Gun")
                        .WithMany()
                        .HasForeignKey("GunId");

                    b.HasOne("CowboyApi.Models.Horse", "Horse")
                        .WithMany()
                        .HasForeignKey("HorseId");

                    b.Navigation("Gun");

                    b.Navigation("Horse");
                });
#pragma warning restore 612, 618
        }
    }
}
