using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Data;

namespace EFCoreMigrationTestWithInheritence_Psql.DatabaseConfiguration
{
    internal class UserHasRelationToRoleConfiguration : IEntityTypeConfiguration<UserHasRelationToRole>
    {
        public void Configure(EntityTypeBuilder<UserHasRelationToRole> builder)
        {
            string tableName = DbContextExtension.GetTableName(typeof(UserHasRelationToRole));
            builder.ToTable(tableName);
            builder.HasKey(ut => new { ut.RoleForeignKey, ut.UserForeignKey });

            var fk1Index = DbContextExtension.GetIndexForFkName(nameof(UserHasRelationToRole),nameof(UserHasRelationToRole.Id),nameof(User));
            builder.HasIndex(e => e.UserForeignKey, fk1Index);

            var fk2Index = DbContextExtension.GetIndexForFkName(nameof(UserHasRelationToRole), nameof(UserHasRelationToRole.Id), nameof(Role));
            builder.HasIndex(e => e.RoleForeignKey, fk2Index);

            builder.Property(ut => ut.Id)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserHasRelationToRoleId(fromDb))
                .HasColumnName(DbContextExtension.UuidName);

            builder.Property(ut => ut.RoleForeignKey)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasDefaultValue(new RoleId(Shared.Const.UserConst.Role.User))
                .HasConversion(toDb => toDb.Uuid, fromDb => new RoleId(fromDb))
                .HasColumnName("role_id");

            builder.Property(ut => ut.UserForeignKey)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName("user_id");

            var userRelationToUserFkName = DbContextExtension.GetForeignKeyName(nameof(UserHasRelationToRole),nameof(UserHasRelationToRole.UserForeignKey), nameof(User));
            builder.HasOne(d => d.User)
                .WithMany(p => p.UserHasRelationToRoles)
                .HasForeignKey(d => d.UserForeignKey)
                .HasConstraintName(userRelationToUserFkName);

            var userRelationToRoleFkName = DbContextExtension.GetForeignKeyName(nameof(UserHasRelationToRole), nameof(UserHasRelationToRole.RoleForeignKey), nameof(Role));
            builder.HasOne(d => d.Role)
                .WithMany(p => p.UserHasRelationToRoles)
                .HasForeignKey(d => d.RoleForeignKey)
                .HasConstraintName(userRelationToRoleFkName);
        }
    }
}