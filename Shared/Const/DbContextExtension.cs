using Shared.Entities.Users;
using Shared.Primitives;
using Shared.ValueObjects.Ids;
using System.Text;

namespace Shared.Const
{
    public static partial class DbContextExtension
    {
        public struct ColumnNameDefinitions
        {
            public const string UuidName = "uuid";
            public const string Name = "name";
            public const string Description = "description";

            public struct UserSpecific
            {
                public const string CreatedByUser = "created_by_uuid";
                public const string ModifiedByUser = "modified_by_uuid";
                public const string DeletedByUser = "deleted_by_uuid";
            }

            public struct TimeSpecific
            {
                public const string CreatedTime = "created_time";
                public const string ModifiedTime = "modified_time";
                public const string DeletedTime = "deleted_time";
            }
        }
        public struct ConstraintNameDefinitions
        {

        }
        public struct IndexNameDefinitions
        {
            public const string PrimaryKeyIndex = "PRIMARY";
        }

        public struct ColumnLength
        {
            public const int Ids = 36;
            public const int Names = 64;
            public const int PasswordLength = 32;
            public const int Descriptions = 255;
            public const int FileExtension = 5;
            public const int MimeTypes = 50;
            public const int PathDescriptors = 1024;
            public const int Base64 = 4096;
            public const int EmailSubject = 255;
            public const int EmailAddrLength = 255;
        }

        public static Func<Type, string> GetTableName = new Func<Type, string>((type) =>
        {
            string typeName = type.Name;
            string tableName = null;
            StringBuilder result = new StringBuilder();

            foreach (char character in typeName)
            {
                if (char.IsUpper(character))
                {
                    result.Append('_');
                }
                result.Append(character);
            }
            tableName = result.ToString().TrimStart('_');

            return ($"{tableName}").ToLower();
        });

        public static Func<string, string> GetIndexName = new Func<string, string>((name) =>
        { 
            return ($"IDX_{name}").ToUpper(); 
        });

        public static Func<string, string, string, string> GetIndexForFkName = new Func<string, string, string, string>((fromEntity, fromEntityKeyName, foreignEntityName) =>
        { 
            return ($"IDX_FK_{fromEntity}_{fromEntityKeyName}_{foreignEntityName}").ToUpper(); 
        });

        public static Func<string, string, string, string> GetForeignKeyName = new Func<string, string, string, string>((fromEntity,fromEntityKeyName, to) =>
        { 
            return ($"FK_{fromEntity}_{fromEntityKeyName}_TO_{to}").ToUpper(); 
        });

        public static EUser GetRootUser()
        {
            EUser rootUser = EUser.Create(
                new UserId(UserConst.RootUserId),
                "Root",
                $"root@localhost",
                "abcd1234",
                new UserTypeId(UserConst.UserType.Root),
                new CustomDateTime(DateTime.Now),
                null,
                null,
                null,
                null,
                null);
            return rootUser;
        }
        public static List<EUser> GetTestSet()
        {
            List<EUser> testSet = new List<EUser>();
            for(int i = 0;i<10;i++)
            {
                var var1 = EUser.Create(
                    new UserId(Guid.NewGuid()),
                    $"Test{i}",
                    $"test{i}@localhost",
                    "abcd1234",
                    new UserTypeId(UserConst.UserType.Root),
                    new CustomDateTime(DateTime.Now),
                    new UserId(UserConst.RootUserId),
                    new CustomDateTime(DateTime.Now),
                    null,
                    null,
                    null);

                testSet.Add(var1);
            }
            return testSet;
        }
    }
}
