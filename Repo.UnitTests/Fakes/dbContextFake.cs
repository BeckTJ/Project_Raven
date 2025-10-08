using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repo.UnitTests.Fakes;

public class dbContextFake
{
    public static ravenContext? CreateRawMaterialDBContext()
    {
        var options = new DbContextOptionsBuilder<ravenContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var dbContext = new ravenContext(options); dbContext.RawMaterialLogs.AddRange(RavenDBContextFakeBuilder.RawMaterialLogFake().AsQueryable());
        dbContext.SaveChanges();
        return dbContext;
    }
    public static ravenContext? CreateVendorLotDbContext()
    {
        var options = new DbContextOptionsBuilder<ravenContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var dbContext = new ravenContext(options);
        dbContext.MaterialVendorLots.AddRange(RavenDBContextFakeBuilder.VendorLotFake().AsQueryable());
        dbContext.SaveChanges();
        return dbContext;
    }
    public static ravenContext? CreateMaterialVendorDbContext()
    {
        var options = new DbContextOptionsBuilder<ravenContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var dbContext = new ravenContext(options);
        dbContext.RawMaterialVendors.AddRange(VendorDBContextFakeBuilder.MaterialVendorFake().AsQueryable());
        dbContext.SaveChanges();
        return dbContext;
    }
}