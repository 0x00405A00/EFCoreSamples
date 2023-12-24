using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using Shared.Const;
using Shared.Entities.Users;
using System.Xml.Linq;

namespace EFCoreMigrationTestWithInheritence_Psql.DatabaseConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            string tableName = DbContextExtension.GetTableName(typeof(User));
            builder.ToTable(tableName);
            builder.HasKey(ut => ut.Id);

            var keyIndex = DbContextExtension.GetIndexName(nameof(User.Id));
            builder.HasIndex(e => e.Id, keyIndex);

            builder.Property(ut => ut.Id)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName(DbContextExtension.UuidName);

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

            var userToUserTypeFkName = DbContextExtension.GetForeignKeyName(nameof(User), nameof(User.Id), nameof(UserType));
            builder.HasOne(d => d.UserType)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName(userToUserTypeFkName);

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
                //CreatedTime = DateTime.Now,
                Email = $"root@localhost",
                UserTypeId = new UserTypeId(UserConst.UserType.Root),
                Id = new UserId(UserConst.RootUserId)
            };
            builder.HasData(rootUser);
        }
    }
}