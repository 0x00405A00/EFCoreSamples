﻿// <auto-generated />
using System;
using EFCoreMigrationTestWithInheritence_MySql_Updated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    [DbContext(typeof(NewContext))]
    [Migration("20231224140737_AddDeletedByUser")]
    partial class AddDeletedByUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Shared.Entities.Roles.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("uuid");

                    b.Property<Guid>("CreatedByUserForeignKey")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"))
                        .HasColumnName("created_by_uuid");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 12, 24, 15, 7, 37, 561, DateTimeKind.Local).AddTicks(3107))
                        .HasColumnName("created_time");

                    b.Property<Guid?>("DeletedByUserForeignKey")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("deleted_by_uuid");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_time");

                    b.Property<Guid?>("LastModifiedByUserForeignKey")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("modified_by_uuid");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_modified_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CreatedByUserForeignKey" }, "IDX_FK_TENTITY_CREATEDBYUSER_USER");

                    b.HasIndex(new[] { "DeletedByUserForeignKey" }, "IDX_FK_TENTITY_DELETEDBYUSER_USER");

                    b.HasIndex(new[] { "LastModifiedByUserForeignKey" }, "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER");

                    b.HasIndex(new[] { "Id" }, "IDX_TENTITYID");

                    b.ToTable("role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"),
                            CreatedByUserForeignKey = new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                            CreatedTime = new DateTime(2023, 12, 24, 15, 7, 37, 561, DateTimeKind.Local).AddTicks(4163),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"),
                            CreatedByUserForeignKey = new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                            CreatedTime = new DateTime(2023, 12, 24, 15, 7, 37, 561, DateTimeKind.Local).AddTicks(4166),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Shared.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("uuid");

                    b.Property<Guid>("CreatedByUserForeignKey")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"))
                        .HasColumnName("created_by_uuid");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 12, 24, 15, 7, 37, 550, DateTimeKind.Local).AddTicks(1453))
                        .HasColumnName("created_time");

                    b.Property<Guid?>("DeletedByUserForeignKey")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("deleted_by_uuid");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_time");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("email");

                    b.Property<Guid?>("LastModifiedByUserForeignKey")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("modified_by_uuid");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_modified_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("password");

                    b.Property<Guid>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"))
                        .HasColumnName("user_type_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("UserTypeId");

                    b.HasIndex(new[] { "CreatedByUserForeignKey" }, "IDX_FK_TENTITY_CREATEDBYUSER_USER")
                        .HasDatabaseName("IDX_FK_TENTITY_CREATEDBYUSER_USER1");

                    b.HasIndex(new[] { "DeletedByUserForeignKey" }, "IDX_FK_TENTITY_DELETEDBYUSER_USER")
                        .HasDatabaseName("IDX_FK_TENTITY_DELETEDBYUSER_USER1");

                    b.HasIndex(new[] { "LastModifiedByUserForeignKey" }, "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER")
                        .HasDatabaseName("IDX_FK_TENTITY_LASTMODIFIEDTIME_USER1");

                    b.HasIndex(new[] { "Id" }, "IDX_TENTITYID")
                        .HasDatabaseName("IDX_TENTITYID1");

                    b.ToTable("user", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                            CreatedTime = new DateTime(2023, 12, 24, 15, 7, 37, 557, DateTimeKind.Local).AddTicks(8626),
                            Email = "root@localhost",
                            Name = "Root",
                            Password = "abcd1234",
                            UserTypeId = new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f")
                        });
                });

            modelBuilder.Entity("Shared.Entities.Users.UserHasRelationToRole", b =>
                {
                    b.Property<Guid>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("uuid");

                    b.Property<Guid>("CreatedByUserForeignKey")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"))
                        .HasColumnName("created_by_uuid");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 12, 24, 15, 7, 37, 565, DateTimeKind.Local).AddTicks(9370))
                        .HasColumnName("created_time");

                    b.Property<Guid?>("DeletedByUserForeignKey")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("deleted_by_uuid");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_time");

                    b.Property<Guid?>("LastModifiedByUserForeignKey")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("modified_by_uuid");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_modified_time");

                    b.Property<Guid>("RoleForeignKey")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"))
                        .HasColumnName("role_id");

                    b.Property<Guid>("UserForeignKey")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("user_id");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("UsersId");

                    b.HasIndex(new[] { "CreatedByUserForeignKey" }, "IDX_FK_TENTITY_CREATEDBYUSER_USER")
                        .HasDatabaseName("IDX_FK_TENTITY_CREATEDBYUSER_USER2");

                    b.HasIndex(new[] { "DeletedByUserForeignKey" }, "IDX_FK_TENTITY_DELETEDBYUSER_USER")
                        .HasDatabaseName("IDX_FK_TENTITY_DELETEDBYUSER_USER2");

                    b.HasIndex(new[] { "LastModifiedByUserForeignKey" }, "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER")
                        .HasDatabaseName("IDX_FK_TENTITY_LASTMODIFIEDTIME_USER2");

                    b.HasIndex(new[] { "RoleForeignKey" }, "IDX_FK_USERHASRELATIONTOROLE_ROLEFOREIGNKEY_ROLE");

                    b.HasIndex(new[] { "UserForeignKey" }, "IDX_FK_USERHASRELATIONTOROLE_USERFOREIGNKEY_USER");

                    b.HasIndex(new[] { "Id" }, "IDX_TENTITYID")
                        .HasDatabaseName("IDX_TENTITYID2");

                    b.ToTable("user_has_relation_to_role", (string)null);
                });

            modelBuilder.Entity("Shared.Entities.Users.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("uuid");

                    b.Property<Guid>("CreatedByUserForeignKey")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"))
                        .HasColumnName("created_by_uuid");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 12, 24, 15, 7, 37, 544, DateTimeKind.Local).AddTicks(1))
                        .HasColumnName("created_time");

                    b.Property<Guid?>("DeletedByUserForeignKey")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("deleted_by_uuid");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_time");

                    b.Property<Guid?>("LastModifiedByUserForeignKey")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasColumnName("modified_by_uuid");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_modified_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CreatedByUserForeignKey" }, "IDX_FK_TENTITY_CREATEDBYUSER_USER")
                        .HasDatabaseName("IDX_FK_TENTITY_CREATEDBYUSER_USER3");

                    b.HasIndex(new[] { "DeletedByUserForeignKey" }, "IDX_FK_TENTITY_DELETEDBYUSER_USER")
                        .HasDatabaseName("IDX_FK_TENTITY_DELETEDBYUSER_USER3");

                    b.HasIndex(new[] { "LastModifiedByUserForeignKey" }, "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER")
                        .HasDatabaseName("IDX_FK_TENTITY_LASTMODIFIEDTIME_USER3");

                    b.HasIndex(new[] { "Id" }, "IDX_TENTITYID")
                        .HasDatabaseName("IDX_TENTITYID3");

                    b.ToTable("user_type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"),
                            CreatedByUserForeignKey = new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                            CreatedTime = new DateTime(2023, 12, 24, 15, 7, 37, 544, DateTimeKind.Local).AddTicks(847),
                            Name = "User"
                        },
                        new
                        {
                            Id = new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"),
                            CreatedByUserForeignKey = new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                            CreatedTime = new DateTime(2023, 12, 24, 15, 7, 37, 544, DateTimeKind.Local).AddTicks(850),
                            Name = "Root"
                        });
                });

            modelBuilder.Entity("Shared.Entities.Roles.Role", b =>
                {
                    b.HasOne("Shared.Entities.Users.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entities.Users.User", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserForeignKey");

                    b.HasOne("Shared.Entities.Users.User", "LastModifiedByUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedByUserForeignKey");

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("LastModifiedByUser");
                });

            modelBuilder.Entity("Shared.Entities.Users.User", b =>
                {
                    b.HasOne("Shared.Entities.Users.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entities.Users.User", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserForeignKey");

                    b.HasOne("Shared.Entities.Users.User", "LastModifiedByUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedByUserForeignKey");

                    b.HasOne("Shared.Entities.Users.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("LastModifiedByUser");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Shared.Entities.Users.UserHasRelationToRole", b =>
                {
                    b.HasOne("Shared.Entities.Users.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entities.Users.User", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserForeignKey");

                    b.HasOne("Shared.Entities.Users.User", "LastModifiedByUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedByUserForeignKey");

                    b.HasOne("Shared.Entities.Roles.Role", "Role")
                        .WithMany("UserHasRelationToRoles")
                        .HasForeignKey("RoleForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entities.Users.User", "User")
                        .WithMany("UserHasRelationToRoles")
                        .HasForeignKey("UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("LastModifiedByUser");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shared.Entities.Users.UserType", b =>
                {
                    b.HasOne("Shared.Entities.Users.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entities.Users.User", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserForeignKey");

                    b.HasOne("Shared.Entities.Users.User", "LastModifiedByUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedByUserForeignKey");

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("LastModifiedByUser");
                });

            modelBuilder.Entity("Shared.Entities.Roles.Role", b =>
                {
                    b.Navigation("UserHasRelationToRoles");
                });

            modelBuilder.Entity("Shared.Entities.Users.User", b =>
                {
                    b.Navigation("UserHasRelationToRoles");
                });

            modelBuilder.Entity("Shared.Entities.Users.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}