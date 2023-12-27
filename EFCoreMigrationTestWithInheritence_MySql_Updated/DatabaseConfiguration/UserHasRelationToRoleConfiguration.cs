using EFCoreMigrationTestWithInheritence_MySql_Updated.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Roles;
using Shared.Entities.Users;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class UserHasRelationToRoleConfiguration : IEntityTypeConfiguration<UserHasRelationToRole>
    {
        public void Configure(EntityTypeBuilder<UserHasRelationToRole> builder)
        {
            builder.AddDefaultProperties<UserHasRelationToRole, UserHasRelationToRoleId>();

            var fk1Index = DbContextExtension.GetIndexForFkName(nameof(UserHasRelationToRole), nameof(UserHasRelationToRole.UserForeignKey), nameof(EUser));
            builder.HasIndex(e => e.UserForeignKey, fk1Index);

            var fk2Index = DbContextExtension.GetIndexForFkName(nameof(UserHasRelationToRole), nameof(UserHasRelationToRole.RoleForeignKey), nameof(Role));
            builder.HasIndex(e => e.RoleForeignKey, fk2Index);

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

            builder.HasOne(d => d.Role).WithMany(p => p.UserHasRelationToRoles)
                .HasForeignKey(d => d.RoleForeignKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_userRoleToRole");

            /*builder.HasOne(d => d.User).WithMany(p => p.UserHasRelationToRoles)
                .HasForeignKey(d => d.UserForeignKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_userRoleToUser");*/
        }
    }
    internal class UserFriendsConfiguration : IEntityTypeConfiguration<UserFriend>
    {
        public void Configure(EntityTypeBuilder<UserFriend> builder)
        {
            builder.AddDefaultProperties<UserFriend, UserFriendId>();

            var fk1Index = DbContextExtension.GetIndexForFkName(nameof(UserFriend), nameof(UserFriend.UserForeignKey), nameof(EUser));
            builder.HasIndex(e => e.UserForeignKey, fk1Index);

            var fk2Index = DbContextExtension.GetIndexForFkName(nameof(UserFriend), nameof(UserFriend.FriendForeignKey), nameof(EUser));
            builder.HasIndex(e => e.FriendForeignKey, fk2Index);

            builder.Property(ut => ut.FriendForeignKey)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName("friend_id");

            builder.Property(ut => ut.UserForeignKey)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName("user_id");

        }
    }
}