﻿// <auto-generated />
using System;
using Customer_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Customer_Service.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    [Migration("20241007062154_Nx")]
    partial class Nx
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Customer_Service.Models.Customer", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Username");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Username = "user1",
                            Address = "120 Can tho",
                            Birthday = new DateOnly(2003, 1, 12),
                            Email = "huy@gmail.com",
                            Fullname = "Tran Ha Gia Huy",
                            Gender = "Nam",
                            Password = "AQAAAAIAAYagAAAAEHJXbfTj55LpVNKA69UYsecdSsPHJTbNjp3xvax94zoFEBq5cnW4azbx6eEj6RSkow==",
                            Phone = "0399176334"
                        },
                        new
                        {
                            Username = "user2",
                            Address = "120 Can tho",
                            Birthday = new DateOnly(2003, 1, 12),
                            Email = "huy2@gmail.com",
                            Fullname = "Tran Ha Gia Huy2",
                            Gender = "Nam",
                            Password = "AQAAAAIAAYagAAAAENcjyqu6V+g6wIpJpCrxPrdNKhpzN4C4NzhJR3bK9lebJdD7EJa2Z+b+21d+M4XJSA==",
                            Phone = "0399176334"
                        },
                        new
                        {
                            Username = "user3",
                            Address = "120 Can tho",
                            Birthday = new DateOnly(2003, 1, 12),
                            Email = "huy3@gmail.com",
                            Fullname = "Tran Ha Gia Huy3",
                            Gender = "Nam",
                            Password = "AQAAAAIAAYagAAAAEBjHLQBPcdymW2dVH/tKzGraL9RX9Jgl08v00GEkQK0dypJsFeuOcbsX8Pmd/yadVA==",
                            Phone = "0399176334"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
