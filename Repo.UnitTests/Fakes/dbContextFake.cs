using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repo.UnitTests.Fakes;

public class dbContextFake
{
    public static ravenContext? CreateDBContext()
    {
        var options = new DbContextOptionsBuilder<ravenContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var dbContext = new ravenContext(options); dbContext.RawMaterialLogs.AddRange(RavenDBContextFakeBuilder.RawMaterialLogFake().AsQueryable());
        dbContext.SaveChanges();
        return dbContext;
    }
}