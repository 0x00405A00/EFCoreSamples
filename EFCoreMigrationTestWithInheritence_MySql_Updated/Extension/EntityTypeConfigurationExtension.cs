using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Const;
using Shared.Entities.Users;
using Shared.Primitives;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Extension
{
    public static class EntityTypeConfigurationExtension
    {
        public static EntityTypeBuilder<TEntity> AddDefaultProperties<TEntity, TEntityId>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : Entity<TEntityId>
            where TEntityId : Identification
        {
            string tableName = DbContextExtension.GetTableName(typeof(TEntity));
            builder.ToTable(tableName);
            builder.HasKey(ut => ut.Id).HasName("PRIMARY");

            var keyIndex = DbContextExtension.GetIndexName(nameof(TEntity)+"Id");
            builder.HasIndex(e => e.Id, keyIndex);

            builder.Property(ut => ut.Id)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => (TEntityId)Activator.CreateInstance(typeof(TEntityId), new object[] { fromDb }))
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UuidName);

            //User by actions
            var fkIndexCreatedByUser = DbContextExtension.GetIndexForFkName(nameof(TEntity), nameof(User.CreatedByUser), nameof(User));
            builder.HasIndex(e => e.CreatedByUserForeignKey, fkIndexCreatedByUser);
            var fkIndexModifiedByUser = DbContextExtension.GetIndexForFkName(nameof(TEntity), nameof(User.LastModifiedTime), nameof(User));
            builder.HasIndex(e => e.LastModifiedByUserForeignKey, fkIndexModifiedByUser);
            var fkIndexDeletedByUser = DbContextExtension.GetIndexForFkName(nameof(TEntity), nameof(User.DeletedByUser), nameof(User));
            builder.HasIndex(e => e.DeletedByUserForeignKey, fkIndexDeletedByUser);

            builder.Property(ut => ut.CreatedByUserForeignKey)
                .IsRequired()
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasDefaultValue(DbContextExtension.GetRootUser().Id)
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UserSpecific.CreatedByUser);
            builder.Property(ut => ut.LastModifiedByUserForeignKey)
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UserSpecific.ModifiedByUser);
            builder.Property(ut => ut.DeletedByUserForeignKey)
                .HasMaxLength(DbContextExtension.ColumnLength.Ids)
                .HasConversion(toDb => toDb.Uuid, fromDb => new UserId(fromDb))
                .HasColumnName(DbContextExtension.ColumnNameDefinitions.UserSpecific.DeletedByUser);


            builder.HasOne(u => u.CreatedByUser)
                .WithMany()
                .IsRequired()
                .HasForeignKey(fk=>fk.CreatedByUserForeignKey);

            builder.HasOne(u => u.LastModifiedByUser)
                .WithMany()
                .HasForeignKey(fk => fk.LastModifiedByUserForeignKey);

            builder.HasOne(u => u.DeletedByUser)
                .WithMany()
                .HasForeignKey(fk => fk.DeletedByUserForeignKey); 
            
            //Timestamps by action
            builder.Property(ut => ut.CreatedTime)
                .IsRequired()
                .HasDefaultValue(new CustomDateTime(DateTime.Now))
                .HasColumnName("created_time");
            builder.Property(ut => ut.LastModifiedTime)
                .HasColumnName("last_modified_time");
            builder.Property(ut => ut.DeletedTime)
                .HasColumnName("deleted_time");


            return builder;
        }
    }


}