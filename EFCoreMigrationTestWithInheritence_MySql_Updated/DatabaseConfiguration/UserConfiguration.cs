using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Data;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.AddDefaultProperties<User,UserId>();

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);
            builder.Property(ut => ut.Email)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);

            builder.Property(ut => ut.UserTypeId)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasDefaultValue(new UserTypeId(Shared.Const.UserConst.UserType.User))
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserTypeId(fromDb))
                .HasColumnName("user_type_id");

            builder.Property(ut => ut.Password)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);

            /*builder.Property(ut => ut.CreatedTime)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);*/

            /*var userToUserTypeFkName = DbContextExtension.GetForeignKeyName(nameof(User), nameof(User.Id), nameof(UserType));
            builder.HasOne(d => d.UserType)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName(userToUserTypeFkName);*/

            builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserHasRelationToRole>(
                j =>
                {
                    j.HasOne<User>(e=>e.User).WithMany(e=>e.UserHasRelationToRoles).HasForeignKey(e=>e.UserForeignKey);
                    j.HasOne(t=>t.Role).WithMany(e=>e.UserHasRelationToRoles).HasForeignKey(e => e.RoleForeignKey);
                });

            User rootUser = new User()
            {
                Name = "Root",
                Password = "abcd1234",
                CreatedDateTime = new CustomDateTime(DateTime.Now),
                Email = $"root@localhost",
                UserTypeId = new UserTypeId(UserConst.UserType.Root),
                Id = new UserId(UserConst.RootUserId)
            };
            builder.HasData(rootUser);
        }
    }
}