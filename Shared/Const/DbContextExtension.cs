using System.Text;

namespace Shared.Const
{
    public static partial class DbContextExtension
    {
        public const string UuidName = "uuid";
        public struct ColumnLength
        {
            public const int Ids = 36;
            public const int Names = 64;
            public const int Descriptions = 255;
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
        { return ($"IDX_{name}").ToUpper(); });
        public static Func<string, string, string, string> GetIndexForFkName = new Func<string, string, string, string>((fromEntity, fromEntityKeyName, foreignEntityName) =>
        { return ($"IDX_FK_{fromEntity}_{fromEntityKeyName}_{foreignEntityName}").ToUpper(); });
        public static Func<string, string, string, string> GetForeignKeyName = new Func<string, string, string, string>((fromEntity,fromEntityKeyName, to) =>
        { return ($"FK_{fromEntity}_{fromEntityKeyName}_TO_{to}").ToUpper(); });
    }
}
