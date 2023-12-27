using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Users;

namespace EFCoreMigrationTestWithInheritence.DatabaseConfiguration
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
                .HasColumnName("id")
                .HasConversion(toDb => toDb.Uuid, fromDb=> new UserIdent(fromDb));

            builder.Property(ut => ut.Name)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);

            builder.Property(ut => ut.Email)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);

            builder.Property(ut => ut.Password)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);
            builder.Property(ut => ut.CreatedTime)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Names);
        }
    }
}