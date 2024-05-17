using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;

namespace Repo;

internal sealed class VendorRepo : RepoBase<Rawmaterialvendor>, IVendorRepo
{
    public VendorRepo(ravenContext ctx) : base(ctx) { }
    public async Task<IEnumerable<Rawmaterialvendor>> GetAllVendors() =>
        await FindAll().ToListAsync();

    public async Task<IEnumerable<Rawmaterialvendor>> GetAllVendorsWithRawMaterialLogs() =>
        await FindAll()
            .Include(m => m.Rawmateriallogs)
            .ToListAsync();

    public async Task<Rawmaterialvendor> GetVendorByMaterialNumber(int materialNumber) =>
        await FindByCondition(m => m.Materialnumber == materialNumber).FirstAsync();

    public async Task<Rawmaterialvendor> GetVendorByVendorName(string vendorName) =>
        await FindByCondition(m => m.Vendorname == vendorName).FirstAsync();
}