using EFCoreMigrationTestWithInheritence_MySql_Updated.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Users;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.AddDefaultProperties<UserType,UserTypeId>();
            builder.AddAuditableProperties<UserType, UserTypeId>();

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names)
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.Name);

            string createdByUserConstraintName =DbContextExtension.GetForeignKeyName(nameof(UserType),nameof(UserType.CreatedByUserForeignKey),nameof(EUser));
            string modifiedByUserConstraintName = DbContextExtension.GetForeignKeyName(nameof(UserType), nameof(UserType.LastModifiedByUserForeignKey), nameof(EUser));
            string deletedByUserConstraintName = DbContextExtension.GetForeignKeyName(nameof(UserType), nameof(UserType.DeletedByUserForeignKey), nameof(EUser));
            builder.HasOne(u => u.CreatedByUser)
                .WithMany(x => x.CreatedUserTypes)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.CreatedByUserForeignKey)
                .HasConstraintName(createdByUserConstraintName);
            builder.HasOne(u => u.LastModifiedByUser)
                .WithMany(x => x.ModifiedUserTypes)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.LastModifiedByUserForeignKey)
                .HasConstraintName(modifiedByUserConstraintName);
            builder.HasOne(u => u.DeletedByUser)
                .WithMany(x => x.DeletedUserTypes)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.DeletedByUserForeignKey)
                .HasConstraintName(deletedByUserConstraintName);

            var rootUser = DbContextExtension.GetRootUser();
            var userType1 = UserType.Create(
                new UserTypeId(UserConst.UserType.User),
                "User",
                new CustomDateTime(DateTime.Now),
                null,
                null,
                null,
                null,
                null);
            var userType2 = UserType.Create(
                new UserTypeId(UserConst.UserType.Root),
                "Root",
                new CustomDateTime(DateTime.Now),
                null,
                null,
                null,
                null,
                null);
            builder.HasData(userType1, userType2);
        }
    }

}