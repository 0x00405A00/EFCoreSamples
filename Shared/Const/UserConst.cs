namespace Shared.Const
{
    public struct UserConst
    {
        public static readonly Guid RootUserId = new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b");

        public readonly struct UserType
        {
            public UserType()
            {

            }
            public static readonly Guid Root = new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f");
            public static readonly Guid User = new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b");
        }
        public readonly struct Role
        {
            public Role()
            {

            }
            public static readonly Guid Admin = new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f");
            public static readonly Guid User = new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b");
        }
    }
}
