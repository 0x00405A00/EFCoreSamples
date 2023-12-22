﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Data;

namespace EFCoreMigrationTestWithInheritence.DatabaseConfiguration
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            string tableName = DbContextExtension.GetTableName(typeof(UserType));
            builder.ToTable(tableName);
            builder.HasKey(ut => ut.Id);

            var keyIndex = DbContextExtension.GetIndexName(nameof(UserType.Id));
            builder.HasIndex(e => e.Id, keyIndex);

            builder.Property(ut => ut.Id)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasColumnName("id")
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserTypeId(fromDb));

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);

            var userType1 = new UserType { Id = new UserTypeId(Guid.NewGuid()), Name = "User" };
            var userType2 = new UserType { Id = new UserTypeId(Guid.NewGuid()), Name = "Root" };
            builder.HasData(userType1, userType2);
        }
    }

}