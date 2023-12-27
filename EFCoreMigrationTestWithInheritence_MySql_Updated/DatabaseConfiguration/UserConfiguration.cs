using EFCoreMigrationTestWithInheritence_MySql_Updated.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Users;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<EUser>
    {
        public void Configure(EntityTypeBuilder<EUser> builder)
        {
            builder.AddDefaultProperties<EUser, UserId>();
            builder.AddAuditableProperties<EUser, UserId>();

            builder.Property(ut => ut.CreatedByUserForeignKey)
                .IsRequired(false)
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UserSpecific.CreatedByUser);
            builder.Property(ut => ut.LastModifiedByUserForeignKey)
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .IsRequired(false)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UserSpecific.ModifiedByUser);
            builder.Property(ut => ut.DeletedByUserForeignKey)
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .IsRequired(false)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UserSpecific.DeletedByUser);

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names)
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.Name);
            
            builder.Property(ut => ut.Email)
                .IsRequired()
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
                    j.HasOne<EUser>(e => e.User).WithMany(e => e.UserHasRelationToRoles).HasForeignKey(e => e.UserForeignKey);
                    j.HasOne(t => t.Role).WithMany(e => e.UserHasRelationToRoles).HasForeignKey(e => e.RoleForeignKey);
                });

            builder.HasOne(u => u.CreatedByUser)
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(fk => fk.CreatedByUserForeignKey)
                .HasPrincipalKey(pk => pk.Id);

            builder.HasOne(u => u.LastModifiedByUser)
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(fk => fk.LastModifiedByUserForeignKey)
                .HasPrincipalKey(pk => pk.Id);

            builder.HasOne(u => u.DeletedByUser)
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(fk => fk.DeletedByUserForeignKey)
                .HasPrincipalKey(pk => pk.Id);

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