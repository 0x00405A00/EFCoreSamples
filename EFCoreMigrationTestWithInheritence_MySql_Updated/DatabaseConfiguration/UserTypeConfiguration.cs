using EFCoreMigrationTestWithInheritence_MySql_Updated.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Users;
using Shared.Primitives;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.AddDefaultProperties<UserType,UserTypeId>();

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names)
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.Name);

            var rootUser = DbContextExtension.GetRootUser();
            var userType1 = new UserType { Id = new UserTypeId(UserConst.UserType.User),CreatedByUserForeignKey = rootUser.Id, CreatedTime = new CustomDateTime(DateTime.Now), Name = "User" };
            var userType2 = new UserType { Id = new UserTypeId(UserConst.UserType.Root), CreatedByUserForeignKey = rootUser.Id, CreatedTime = new CustomDateTime(DateTime.Now), Name = "Root" };
            builder.HasData(userType1, userType2);
        }
    }

}