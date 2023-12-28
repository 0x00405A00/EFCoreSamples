using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using Shared.Const;
using Shared.Entities.Users;
using System.Xml.Linq;

namespace EFCoreMigrationTestWithInheritence_Psql.DatabaseConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<EUser>
    {
        public void Configure(EntityTypeBuilder<EUser> builder)
        {
            string tableName = DbContextExtension.GetTableName(typeof(EUser));
            builder.ToTable(tableName);
            builder.HasKey(ut => ut.Id);

            var keyIndex = DbContextExtension.GetIndexName(nameof(EUser.Id));
            builder.HasIndex(e => e.Id, keyIndex);

            builder.Property(ut => ut.Id)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Id, fromDb => new UserIdent(fromDb))
                .HasColumnName(DbContextExtension.UuidName);

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);
            builder.Property(ut => ut.Email)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);

            builder.Property(ut => ut.UserTypeForeignKey)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasDefaultValue(new UserTypeIdent(Shared.Const.UserConst.UserType.User))
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserTypeIdent(fromDb))
                .HasColumnName("user_type_id");

            builder.Property(ut => ut.Password)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);
            /*builder.Property(ut => ut.CreatedTime)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);*/

            var userToUserTypeFkName = DbContextExtension.GetForeignKeyName(nameof(EUser), nameof(EUser.Id), nameof(UserType));
            builder.HasOne(d => d.UserType)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeForeignKey)
                .HasConstraintName(userToUserTypeFkName);

            builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserHasRelationToRole>(
                j =>
                {
                    j.HasOne<EUser>(e=>e.User).WithMany(e=>e.UserHasRelationToRoles).HasForeignKey(e=>e.UserForeignKey);
                    j.HasOne(t=>t.Role).WithMany(e=>e.UserHasRelationToRoles).HasForeignKey(e => e.RoleForeignKey);
                });

            EUser rootUser = new User()
            {
                Name = "Root",
                Password = "abcd1234",
                //CreatedTime = DateTime.Now,
                Email = $"root@localhost",
                UserTypeId = new UserTypeIdent(UserConst.UserType.Root),
                Id = new UserIdent(UserConst.RootUserId)
            };
            builder.HasData(rootUser);
        }
    }
}