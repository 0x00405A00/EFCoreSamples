using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Extension
{
    public static class EntityTypeConfigurationExtension
    {
        public static EntityTypeBuilder<TEntity> AddDefaultProperties<TEntity, TEntityId>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : Entity<TEntityId>
            where TEntityId : Identification
        {
            builder.HasKey(ut => ut.Id).HasName(DbContextExtension.IndexNameDefinitions.PrimaryKeyIndex);

            string tableName = DbContextExtension.GetTableName(typeof(TEntity));
            builder.ToTable(tableName);

            //Timestamps by action
            builder.Property(ut => ut.CreatedTime)
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValue(new CustomDateTime(DateTime.Now))
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.TimeSpecific.CreatedTime);
            builder.Property(ut => ut.LastModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.TimeSpecific.ModifiedTime);
            builder.Property(ut => ut.DeletedTime)
                .HasColumnType("datetime")
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.TimeSpecific.DeletedTime);

            builder.Property(ut => ut.Id)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => (TEntityId)Activator.CreateInstance(typeof(TEntityId), new object[] { fromDb }))
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UuidName);

            return builder;
        }
        public static EntityTypeBuilder<TEntity> AddAuditableProperties<TEntity, TEntityId>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : AuditableEntity<TEntityId>
            where TEntityId : Identification
        {

            builder.Property(ut => ut.CreatedByUserForeignKey)
                .IsRequired(false)
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UserSpecific.CreatedByUser);
            builder.Property(ut => ut.LastModifiedByUserForeignKey)
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .IsRequired(false)
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UserSpecific.ModifiedByUser);
            builder.Property(ut => ut.DeletedByUserForeignKey)
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .IsRequired(false)
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UserSpecific.DeletedByUser);
            return builder;
        }
    }
}