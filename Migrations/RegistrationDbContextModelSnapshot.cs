﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student_Registration.DbContexts;

#nullable disable

namespace Student_Registration.Migrations
{
    [DbContext(typeof(RegistrationDbContext))]
    partial class RegistrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Student_Registration.Model.areaModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("area")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("area");
                });

            modelBuilder.Entity("Student_Registration.Model.Gatepass", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("area")
                        .HasColumnType("longtext");

                    b.Property<string>("comming_time")
                        .HasColumnType("longtext");

                    b.Property<string>("commited_time")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("father")
                        .HasColumnType("longtext");

                    b.Property<string>("gid")
                        .HasColumnType("longtext");

                    b.Property<string>("going_time")
                        .HasColumnType("longtext");

                    b.Property<bool>("group")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("group_id")
                        .HasColumnType("char(36)");

                    b.Property<bool>("late")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("late_permission")
                        .HasColumnType("longtext");

                    b.Property<string>("late_reason")
                        .HasColumnType("longtext");

                    b.Property<bool>("monitar")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("permission")
                        .HasColumnType("longtext");

                    b.Property<string>("place")
                        .HasColumnType("longtext");

                    b.Property<string>("reason")
                        .HasColumnType("longtext");

                    b.Property<bool>("returned")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("room")
                        .HasColumnType("longtext");

                    b.Property<string>("standard")
                        .HasColumnType("longtext");

                    b.Property<string>("surname")
                        .HasColumnType("longtext");

                    b.Property<string>("with")
                        .HasColumnType("longtext");

                    b.Property<string>("with_name")
                        .HasColumnType("longtext");

                    b.Property<string>("with_number")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Gatepass");
                });

            modelBuilder.Entity("Student_Registration.Model.OtpModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("gid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("otp")
                        .HasColumnType("bigint");

                    b.Property<bool>("verified")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("otp");
                });

            modelBuilder.Entity("Student_Registration.Model.PlaceModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("place")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("place");
                });

            modelBuilder.Entity("Student_Registration.Model.ReasonModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("reason")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("reasons");
                });

            modelBuilder.Entity("Student_Registration.Model.SabhaModel", b =>
                {
                    b.Property<string>("gid")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("cup_no")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("deparment")
                        .HasColumnType("longtext");

                    b.Property<string>("father")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permit")
                        .HasColumnType("longtext");

                    b.Property<string>("room")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("stndard")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("village")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("gid");

                    b.ToTable("sabha");
                });

            modelBuilder.Entity("Student_Registration.Model.SevaList", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("deparment")
                        .HasColumnType("longtext");

                    b.Property<string>("hod")
                        .HasColumnType("longtext");

                    b.Property<string>("telegram_chat_id")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("seva");
                });

            modelBuilder.Entity("Student_Registration.Model.SpecialEntryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("area")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("gid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("place")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("specialmodel");
                });

            modelBuilder.Entity("Student_Registration.Model.Student_data", b =>
                {
                    b.Property<string>("gid")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("cup_no")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("father")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("room")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("stndard")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("village")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("gid");

                    b.ToTable("students");
                });
#pragma warning restore 612, 618
        }
    }
}
