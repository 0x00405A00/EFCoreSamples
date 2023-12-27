using EFCoreMigrationTestWithInheritence_MySql_Updated.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Roles;
using Shared.Entities.Users;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.AddDefaultProperties<Role, RoleId>();
            builder.AddAuditableProperties<Role, RoleId>();

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.Name);

            string createdByUserConstraintName = DbContextExtension.GetForeignKeyName(nameof(Role), nameof(Role.CreatedByUserForeignKey), nameof(EUser));
            string modifiedByUserConstraintName = DbContextExtension.GetForeignKeyName(nameof(Role), nameof(Role.LastModifiedByUserForeignKey), nameof(EUser));
            string deletedByUserConstraintName = DbContextExtension.GetForeignKeyName(nameof(Role), nameof(Role.DeletedByUserForeignKey), nameof(EUser));
            builder.HasOne(u => u.CreatedByUser)
                .WithMany(x => x.CreatedRoles)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.CreatedByUserForeignKey)
                .HasConstraintName(createdByUserConstraintName);
            builder.HasOne(u => u.LastModifiedByUser)
                .WithMany(x => x.ModifiedRoles)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.LastModifiedByUserForeignKey)
                .HasConstraintName(modifiedByUserConstraintName);
            builder.HasOne(u => u.DeletedByUser)
                .WithMany(x => x.DeletedRoles)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.DeletedByUserForeignKey)
                .HasConstraintName(deletedByUserConstraintName);

            var rootUser = DbContextExtension.GetRootUser();
            var roleAdmin = Role.Create(
                new RoleId(UserConst.Role.Admin),
                "Admin",
                new CustomDateTime(DateTime.Now),
                null,
                null,
                null,
                null,
                null);
            var roleUser = Role.Create(
                new RoleId(UserConst.Role.User),
                "User",
                new CustomDateTime(DateTime.Now),
                null,
                null,
                null,
                null,
                null);
            builder.HasData(roleAdmin, roleUser);
        }
    }

}