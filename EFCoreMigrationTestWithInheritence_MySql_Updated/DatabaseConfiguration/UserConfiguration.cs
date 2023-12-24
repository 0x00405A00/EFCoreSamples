using EFCoreMigrationTestWithInheritence_MySql_Updated.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Users;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.AddDefaultProperties<User,UserId>();

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names)
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.Name);
            
            builder.Property(ut => ut.Email)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names)
                .HasColumnName("email");

            builder.Property(ut => ut.UserTypeId)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasDefaultValue(new UserTypeId(Shared.Const.UserConst.UserType.User))
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserTypeId(fromDb))
                .HasColumnName("user_type_id");

            builder.Property(ut => ut.Password)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names)
                .HasColumnName("password");

            builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserHasRelationToRole>(
                j =>
                {
                    j.HasOne<User>(e => e.User).WithMany(e => e.UserHasRelationToRoles).HasForeignKey(e => e.UserForeignKey);
                    j.HasOne(t => t.Role).WithMany(e => e.UserHasRelationToRoles).HasForeignKey(e => e.RoleForeignKey);
                });

            /*builder.HasMany(u => u.FriendshipRequests)
                .WithMany(r => r.Users)
                .UsingEntity<FriendshipRequest>(
                j =>
                {
                    j.HasOne<User>(e => e.RequestUser).WithMany(e => e.FriendshipRequests).HasForeignKey(e => e.RequestUserForeignKey);
                    j.HasOne(t => t.TargetUser).WithMany(e => e.FriendshipRequests).HasForeignKey(e => e.TargetUserForeignKey);
                });
            builder.HasMany(u => u.UserFriends)
                .WithMany(r => r.Users)
                .UsingEntity<UserFriend>(
                j =>
                {
                    j.HasOne<User>(e => e.User).WithMany(e => e.UserFriends).HasForeignKey(e => e.UserForeignKey);
                    j.HasOne(t => t.Friend).WithMany(e => e.UserFriends).HasForeignKey(e => e.FriendForeignKey);
                });*/

            builder.HasData(DbContextExtension.GetRootUser());
        }
    }
}