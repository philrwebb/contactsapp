﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sustain.DbContexts;

#nullable disable

namespace contactsapp.Migrations
{
    [DbContext(typeof(SustainContext))]
    [Migration("20231008070632_metermig11")]
    partial class metermig11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sustain.Entities.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ContactId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Sustain.Entities.Meter", b =>
                {
                    b.Property<int>("MeterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeterId"), 1L, 1);

                    b.Property<string>("MeterDescription")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MeterName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("MeterTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.Property<string>("UtilityAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeterId");

                    b.HasIndex("MeterTypeId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Meter");
                });

            modelBuilder.Entity("Sustain.Entities.MeterReading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MeterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReadingDatetime")
                        .HasColumnType("datetime2");

                    b.Property<double>("ReadingValue")
                        .HasColumnType("float");

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MeterId");

                    b.ToTable("MeterReading");
                });

            modelBuilder.Entity("Sustain.Entities.MeterType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeUnitOfMeasure")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("effFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("effTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("typeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeLongDescription")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("typeShortDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MeterType");
                });

            modelBuilder.Entity("Sustain.Entities.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolId"), 1L, 1);

                    b.Property<string>("SchoolLocation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SchoolName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SchoolTypeId")
                        .HasColumnType("int");

                    b.HasKey("SchoolId");

                    b.HasIndex("SchoolTypeId");

                    b.ToTable("School");
                });

            modelBuilder.Entity("Sustain.Entities.SchoolType", b =>
                {
                    b.Property<int>("SchoolTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolTypeId"), 1L, 1);

                    b.Property<string>("TypeLongDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeShortDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SchoolTypeId");

                    b.ToTable("SchoolType");
                });

            modelBuilder.Entity("Sustain.Entities.Meter", b =>
                {
                    b.HasOne("Sustain.Entities.MeterType", "MeterType")
                        .WithMany()
                        .HasForeignKey("MeterTypeId");

                    b.HasOne("Sustain.Entities.School", null)
                        .WithMany("Meters")
                        .HasForeignKey("SchoolId");

                    b.Navigation("MeterType");
                });

            modelBuilder.Entity("Sustain.Entities.MeterReading", b =>
                {
                    b.HasOne("Sustain.Entities.Meter", "meter")
                        .WithMany("MeterReadings")
                        .HasForeignKey("MeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("meter");
                });

            modelBuilder.Entity("Sustain.Entities.School", b =>
                {
                    b.HasOne("Sustain.Entities.SchoolType", "SchoolType")
                        .WithMany()
                        .HasForeignKey("SchoolTypeId");

                    b.Navigation("SchoolType");
                });

            modelBuilder.Entity("Sustain.Entities.Meter", b =>
                {
                    b.Navigation("MeterReadings");
                });

            modelBuilder.Entity("Sustain.Entities.School", b =>
                {
                    b.Navigation("Meters");
                });
#pragma warning restore 612, 618
        }
    }
}
