using EFCoreMigrationTestWithInheritence_MySql_Updated.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Mail;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    internal class EmailTypeConfiguration : IEntityTypeConfiguration<EmailType>
    {
        public void Configure(EntityTypeBuilder<EmailType> builder)
        {
            builder.AddDefaultProperties<EmailType, EmailTypeId>();

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names)
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.Name);

            var toType = EmailType.Create(
                new EmailTypeId(Email.Type.To),
                "to",
                new CustomDateTime(DateTime.Now),
                null,
                null);

            var  ccType = EmailType.Create(
                new EmailTypeId(Email.Type.Cc),
                "cc",
                new CustomDateTime(DateTime.Now),
                null,
                null);

            var bccType = EmailType.Create(
                new EmailTypeId(Email.Type.Bcc),
                "bcc",
                new CustomDateTime(DateTime.Now),
                null,
                null);

            builder.HasData(toType, ccType, bccType);
        }
    }

}