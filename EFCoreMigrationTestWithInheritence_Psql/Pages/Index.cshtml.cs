using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shared.Const;
using Shared.Data;

namespace EFCoreMigrationTestWithInheritence_Psql.Pages
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
            var testUserSelect = DbSet
                .Include(x => x.UserHasRelationToRoles)
                .ThenInclude(y=>y.Role)
                .Include(x=>x.UserType)
                .AsNoTracking()
                .Where(x => x.Name == "Root")
                .AsSingleQuery()
                .ToList();

            //Asynchron Tests
            const string newName = "Root_xyz";
            var testUserSelectAsync = await dbContext.Users.Where(x => x.Name == "Test")
            .FirstOrDefaultAsync();

            testUserSelectAsync.Name = newName;
            await dbContext.SaveChangesAsync();

            var testUsersSelectAsync = await dbContext.Users.Where(x => x.Name.StartsWith("Test_"))
                                                 .AsTracking()
                                                 .ToListAsync();


            //DML Tests->Update with tracked Entity
            testUserSelectAsync = testUsersSelectAsync.Where(x => x.Name == newName)
                                                      .FirstOrDefault();


            testUserSelectAsync.Name = newName.Substring(0, newName.Length - 4);
            await dbContext.SaveChangesAsync();


            //DML Tests->Insert new Entity
            var randNumber = Random.Shared.Next(testUsersSelectAsync.Count, testUsersSelectAsync.Count * 2);
            var name = $"{testUserSelectAsync.Name}_{randNumber}";
            User newUser = new User()
            {
                Name = name,
                Password = testUserSelectAsync.Password,
                //CreatedTime = DateTime.Now,
                Email = $"{name}@test.com",
                UserTypeId = new UserTypeId(UserConst.UserType.User),
                Id = new UserId(Guid.NewGuid())
            };
            await dbContext.Set<User>().AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return new OkResult();
        }
    }
}
