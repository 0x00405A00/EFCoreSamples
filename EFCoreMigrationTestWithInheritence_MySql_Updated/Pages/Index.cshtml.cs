using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shared.Const;
using Shared.Entities.Users;
using Shared.Extension;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NewContext dbContext;

        public IndexModel(
            ILogger<IndexModel> logger,
            NewContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostTestEFCore()
        {


            var DbSet = dbContext.Set<User>();
            //Synchron Tests
            var rootUserSelect = DbSet
                .Include(x => x.UserHasRelationToRoles)
                .ThenInclude(y => y.Role)
                .Include(x=>x.CreatedByUser)
                .Include(x => x.UserType)
                .Include(x => x.UserHasRelationToFriendsLeft)
                .ThenInclude(x=>x.UserFriend)
                .Include(x => x.UserHasRelationToFriendsRight)
                .ThenInclude(x => x.User)
                .Include(x => x.FriendshipRequestsWhereIamRequester)
                .ThenInclude(x => x.TargetUser)
                .Include(x => x.FriendshipRequestsWhereIamTarget)
                .ThenInclude(x => x.RequesterUser)
                .AsNoTracking()
                .Where(x => x.Id == UserConst.RootUserId.ToIdentification<UserId>())
                .AsSingleQuery()
                .ToList();
            var testUserSelect = DbSet
                .Include(x => x.UserHasRelationToRoles)
                .ThenInclude(y => y.Role)
                .Include(x => x.CreatedByUser)
                .Include(x => x.UserType)
                .Include(x => x.UserHasRelationToFriendsLeft)
                .ThenInclude(x => x.UserFriend)
                .Include(x => x.UserHasRelationToFriendsRight)
                .ThenInclude(x => x.User)
                .Include(x => x.FriendshipRequestsWhereIamRequester)
                .ThenInclude(x => x.TargetUser)
                .Include(x => x.FriendshipRequestsWhereIamTarget)
                .ThenInclude(x => x.RequesterUser)
                .AsNoTracking()
                .Where(x => x.Name == "Test1")
                .AsSingleQuery()
                .ToList();

            //Asynchron Tests
            const string newName = "Root_xyz";
            User testUserSelectAsync = await dbContext.Users.Where(x => x.Name == "Test")
                                                 .FirstOrDefaultAsync();

            testUserSelectAsync.SetName(newName);
            await dbContext.SaveChangesAsync();

            var testUsersSelectAsync = await dbContext.Users.Where(x => x.Name.StartsWith("Test_"))
                                                 .AsTracking()
                                                 .ToListAsync();


            //DML Tests->Update with tracked Entity
            testUserSelectAsync = testUsersSelectAsync.Where(x => x.Name == newName)
                                                      .FirstOrDefault();


            testUserSelectAsync.SetName(newName.Substring(0, newName.Length - 4));
            await dbContext.SaveChangesAsync();


            //DML Tests->Insert new Entity
            var randNumber = Random.Shared.Next(testUsersSelectAsync.Count, testUsersSelectAsync.Count * 2);
            var name = $"{testUserSelectAsync.Name}_{randNumber}";
            User newUser = global::Shared.Entities.Users.User.Create(
                new UserId(UserConst.RootUserId),
                name,
                 $"{name}@test.com",
                testUserSelectAsync.Password,
                new UserTypeId(Guid.NewGuid()),
                new CustomDateTime(DateTime.Now),
                null,
                null,
                null,
                null,
                null); 
            await dbContext.Set<User>().AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return new OkResult();
        }
    }
}
