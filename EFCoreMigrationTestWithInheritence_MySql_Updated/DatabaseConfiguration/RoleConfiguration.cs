using EFCoreMigrationTestWithInheritence_MySql_Updated.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Roles;
using Shared.Primitives;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.AddDefaultProperties<Role,RoleId>();

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names)
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.Name);

            var rootUser = DbContextExtension.GetRootUser();
            var roleAdmin = new Role { Id = new RoleId(UserConst.Role.Admin), CreatedByUserForeignKey = rootUser.Id, CreatedTime = new CustomDateTime(DateTime.Now), Name = "Admin" };
            var roleUser = new Role { Id = new RoleId(UserConst.Role.User), CreatedByUserForeignKey = rootUser.Id,  CreatedTime = new CustomDateTime(DateTime.Now), Name = "User" };
            builder.HasData(roleAdmin, roleUser);
        }
    }

}