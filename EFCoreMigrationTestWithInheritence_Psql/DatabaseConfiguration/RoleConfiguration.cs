using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Data;

namespace EFCoreMigrationTestWithInheritence_Psql.DatabaseConfiguration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            string tableName = DbContextExtension.GetTableName(typeof(Role));
            builder.ToTable(tableName);
            builder.HasKey(ut => ut.Id);

            var keyIndex = DbContextExtension.GetIndexName(nameof(Role.Id));
            builder.HasIndex(e => e.Id, keyIndex);

            builder.Property(ut => ut.Id)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasColumnName(DbContextExtension.UuidName)
                .HasConversion(toDb => toDb.Uuid, fromDb => new RoleId(fromDb));

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);

            var roleAdmin = new Role { Id = new RoleId(UserConst.Role.Admin), Name = "Admin" };
            var roleUser = new Role { Id = new RoleId(UserConst.Role.User), Name = "User" };
            builder.HasData(roleAdmin, roleUser);
        }
    }

}