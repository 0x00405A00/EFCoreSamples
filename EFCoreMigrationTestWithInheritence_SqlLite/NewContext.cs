using EFCoreMigrationTestWithInheritence_SqlLite.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.Entities.Users;

namespace EFCoreMigrationTestWithInheritence_SqlLite
{
    public class NewContext: DbContext
    {
        #region Const

        #endregion
        #region Consumed DI Services
        public IConfiguration _configuration { get; }
        public DbContextOptions<NewContext> Options { get; }
        #endregion
        #region DbSets
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
        #region Ctor
        public NewContext():base()
        {

        }
        public NewContext(DbContextOptions<NewContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        #endregion
        #region Model
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        {
            optionsBuilder.UseSqlite(ServiceExtension.DatabaseString); 
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            optionsBuilder.ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
            optionsBuilder.EnableSensitiveDataLogging(true);
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
        #endregion
    }
}
