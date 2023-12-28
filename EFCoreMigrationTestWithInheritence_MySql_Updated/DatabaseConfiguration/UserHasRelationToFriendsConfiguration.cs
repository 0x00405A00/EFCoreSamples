using EFCoreMigrationTestWithInheritence_MySql_Updated.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Users;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class UserHasRelationToFriendsConfiguration : IEntityTypeConfiguration<UserHasRelationToFriend>
    {
        public void Configure(EntityTypeBuilder<UserHasRelationToFriend> builder)
        {
            builder.AddDefaultProperties<UserHasRelationToFriend, UserHasRelationToFriendId>();

            var fk1Index = DbContextExtension.GetIndexForFkName(nameof(UserHasRelationToFriend), nameof(UserHasRelationToFriend.UserForeignKey), nameof(EUser));
            builder.HasIndex(e => e.UserForeignKey, fk1Index);

            var fk2Index = DbContextExtension.GetIndexForFkName(nameof(UserHasRelationToFriend), nameof(UserHasRelationToFriend.UserFriendForeignKey), nameof(EUser));
            builder.HasIndex(e => e.UserFriendForeignKey, fk2Index);

            builder.Property(ut => ut.UserFriendForeignKey)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName("friend_id");

            builder.Property(ut => ut.UserForeignKey)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName("user_id");

            builder.HasKey(e => new { e.UserForeignKey, e.UserFriendForeignKey });

            string userFriendsUserToUserConstraintName = DbContextExtension.GetForeignKeyName(nameof(UserHasRelationToFriend), nameof(UserHasRelationToFriend.UserForeignKey), nameof(EUser));
            string userFriendsFriendToUserConstraintName = DbContextExtension.GetForeignKeyName(nameof(UserHasRelationToFriend), nameof(UserHasRelationToFriend.UserFriendForeignKey), nameof(EUser));
            builder.HasOne(e => e.User)
                .WithMany(x => x.UserHasRelationToFriendsLeft)
                .HasForeignKey(x => x.UserForeignKey)
                .HasConstraintName(userFriendsUserToUserConstraintName)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.UserFriend)
                .WithMany(e => e.UserHasRelationToFriendsRight)
                .HasForeignKey(e => e.UserFriendForeignKey)
                .HasConstraintName(userFriendsFriendToUserConstraintName)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}