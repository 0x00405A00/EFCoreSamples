﻿// <auto-generated />
using System;
using EFCoreMigrationTestWithInheritence_SqlLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreMigrationTestWithInheritence_SqlLite.Migrations
{
    [DbContext(typeof(NewContext))]
    [Migration("20231218232930_BaseDataTest_DuplicateValuesInUserTypesTest")]
    partial class BaseDataTest_DuplicateValuesInUserTypesTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Shared.Data.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedTime")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IDX_ID");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Shared.Data.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IDX_ID")
                        .HasDatabaseName("IDX_ID1");

                    b.ToTable("user_type", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
