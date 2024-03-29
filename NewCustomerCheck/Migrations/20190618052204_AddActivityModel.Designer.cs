﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewCustomerCheck.Models;

namespace NewCustomerCheck.Migrations
{
    [DbContext(typeof(NewCustomerCheckContext))]
    [Migration("20190618052204_AddActivityModel")]
    partial class AddActivityModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("NewCustomerCheck.Models.ActivityModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivityApiID");

                    b.Property<int>("ActivityKindEnum");

                    b.Property<string>("ActivityName");

                    b.HasKey("ID");

                    b.ToTable("ActivityModel");
                });
#pragma warning restore 612, 618
        }
    }
}
