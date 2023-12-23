using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Data;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration
{
    public static class EntityTypeConfigurationExtension
    {
        public static EntityTypeBuilder<TEntity> AddDefaultProperties<TEntity,TEntityId>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : Entity<TEntityId>
            where TEntityId : Identification
        {
            string tableName = DbContextExtension.GetTableName(typeof(User));
            builder.ToTable(tableName);
            builder.HasKey(ut => ut.Id).HasName("PRIMARY");

            var keyIndex = DbContextExtension.GetIndexName(nameof(User.Id));
            builder.HasIndex(e => e.Id, keyIndex);

            builder.Property(ut => ut.Id)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => (TEntityId)Activator.CreateInstance(typeof(TEntityId), new object[] { fromDb }))
                .HasColumnName(DbContextExtension.UuidName);

            builder.Property(ut => ut.CreatedDateTime)
                .IsRequired();

            builder.Property(ut => ut.ModifiedDateTime);

            builder.Property(ut => ut.DeletedDateTime);

            return builder;
        }
    }


}