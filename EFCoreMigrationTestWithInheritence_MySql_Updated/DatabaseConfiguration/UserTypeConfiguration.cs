using EFCoreMigrationTestWithInheritence_MySql_Updated.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Mail;
using Shared.Entities.Users;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.AddDefaultProperties<UserType, UserTypeId>();
            builder.AddAuditableProperties<UserType, UserTypeId>();

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names)
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.Name);

            builder.AddAuditableConstraints<UserType, UserTypeId>();

            var userType1 = UserType.Create(
                new UserTypeId(UserConst.UserType.User),
                "User",
                new CustomDateTime(DateTime.Now),
                null,
                null,
                null,
                null,
                null);

            var userType2 = UserType.Create(
                new UserTypeId(UserConst.UserType.Root),
                "Root",
                new CustomDateTime(DateTime.Now),
                null,
                null,
                null,
                null,
                null);

            builder.HasData(userType1, userType2);
        }
    }
    internal class MailOutboxConfiguration : IEntityTypeConfiguration<MailOutbox>
    {
        public void Configure(EntityTypeBuilder<MailOutbox> builder)
        {
            builder.AddDefaultProperties<MailOutbox, MailOutboxId>();

            builder.Property(ut => ut.From)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.EmailAddrLength)
                .HasColumnName("from");

            builder.Property(ut => ut.Subject)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.EmailSubject)
                .HasColumnName("subject");

            builder.Property(ut => ut.Body)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names)
                .HasColumnName("body");

            builder.Property(ut => ut.IsBodyHtml)
                .IsRequired(false)
                .HasColumnType("tinyint(1)")
                .HasDefaultValue(false)
                .HasComment("boolean value to describe if email contain html content")
                .HasColumnName("is_body_html");
        }
    }
}