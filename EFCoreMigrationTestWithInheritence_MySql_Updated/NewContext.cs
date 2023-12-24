using EFCoreMigrationTestWithInheritence_MySql_Updated.Converter;
using EFCoreMigrationTestWithInheritence_MySql_Updated.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Shared.EFCore;
using Shared.Entities.Roles;
using Shared.Entities.Users;
using Shared.Primitives;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated
{
    public class NewContext : DbContext
    {
        #region Const
        public const string ConnectionStringAlias = "JellyfishMySqlDatabase";

        #endregion
        #region Consumed DI Services
        public IConfiguration _configuration { get; }
        public DbContextOptions<NewContext> Options { get; }
        #endregion
        #region DbSets
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserHasRelationToRole> UserHasRelationToRoles { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        #endregion
        #region Ctor
        public NewContext() : base()
        {

        }
        public NewContext(DbContextOptions<NewContext> dbContextOptions) : base(dbContextOptions)
        {
#warning IMPORTANT: MySql Compability is currently working with current packages: \
            /*Microsoft.EntityFrameworkCore: 8.0.0 \
            Microsoft.EntityFrameworkCore.Design 8.0.0:
            Microsoft.EntityFrameworkCore.Tools 8.0.0:
            MySql.Data 8.2.0:
            MySql.EntityFrameworkCore 8.0.0:

            MySql Server Version: 8.2.0*/
        }
        #endregion
        #region Model
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        {
            string connectionString = @"server=127.0.0.1;port=33306;uid=jellyfish;pwd=meinDatabasePassword!;database=jellyfish_ddd_driver_updated_test;charset=utf8mb4;";
            
            optionsBuilder.UseMySQL(connectionString);
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            optionsBuilder.ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.AddInterceptors(new DatabaseReaderInterceptor());
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

#warning Before any start, check if u changed the entity structure in IEntityConfiguration classes. When any changes are done, please migrate to database 
#warning Documentation: https://learn.microsoft.com/de-de/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //pay attention to dependency order (chicken egg problem)

            //Initial Migration: PS C:\Users\Mika\source\repos\jellyfish-backend-ddd\Presentation> dotnet ef migrations add InitialCreate --context ApplicationDbContext
            //Current Problem: A key cannot be configured on 'Entity<Identification>' because it is a derived type.The key must be configured on the root type 'Entity'.If you did not intend for 'Entity' to be included in the model, ensure that it is not referenced by a DbSet property on your context, referenced in a configuration call to ModelBuilder, or referenced from a navigation on a type that is included in the model.
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserHasRelationToRoleConfiguration());

            /*modelBuilder.ApplyConfiguration<UserFriend>(new UserFriendConfiguration());
            modelBuilder.ApplyConfiguration<FriendshipRequest>(new UserFriendshipRequestConfiguration());
            modelBuilder.ApplyConfiguration<Role>(new RoleConfiguration());
            modelBuilder.ApplyConfiguration<UserRole>(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration<Auth>(new AuthConfiguration());
            modelBuilder.ApplyConfiguration<Chat>(new ChatConfiguration());
            modelBuilder.ApplyConfiguration<ChatMember>(new ChatMemberConfiguration());
            modelBuilder.ApplyConfiguration<Message>(new ChatMessageConfiguration());
            modelBuilder.ApplyConfiguration<EmailType>(new EmailTypeConfiguration());
            modelBuilder.ApplyConfiguration<MailOutbox>(new MailConfiguration());
            modelBuilder.ApplyConfiguration<MailOutboxRecipient>(new MailRecipientConfiguration());
            modelBuilder.ApplyConfiguration<MailOutboxAttachment>(new MailAttachmentConfiguration());*/

            //modelBuilder.ApplyConfigurationsFromAssembly ignore any order so dependencies which are order depend could not be created (app runs in exception)

            //Data seeding: Schema initial data with: https://learn.microsoft.com/de-de/ef/core/modeling/data-seeding

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<CustomDateTime>()
                .HaveConversion<CustomDateTimeConverter>();
        }
        #endregion
    }
}
