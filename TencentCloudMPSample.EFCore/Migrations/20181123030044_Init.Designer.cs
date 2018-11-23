﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TencentCloudMPSample.EFCore;

namespace TencentCloudMPSample.EFCore.Migrations
{
    [DbContext(typeof(TencentCloudDbContext))]
    [Migration("20181123030044_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TencentCloudMPSample.EFCore.Models.WeixinInteraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Request")
                        .HasMaxLength(1000);

                    b.Property<string>("Response")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.ToTable("WeixinInteractions");
                });
#pragma warning restore 612, 618
        }
    }
}
