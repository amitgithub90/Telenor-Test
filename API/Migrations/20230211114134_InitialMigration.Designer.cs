// <auto-generated />
using System;
using API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppointmentDbContext))]
    [Migration("20230211114134_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("API.Models.Appointment", b =>
                {
                    b.Property<int>("AppId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DateTime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("DateTime");

                    b.HasKey("AppId");

                    b.ToTable("Appointment", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
