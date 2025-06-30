
using System.Runtime.Serialization;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;

namespace Repo;

internal sealed class VendorLotRepo : RepoBase<MaterialVendorLot>, IVendorLotRepo
{
    public VendorLotRepo(ravenContext ctx) : base(ctx) { }

    public async Task<IEnumerable<MaterialVendorLot>> GetAllVendorLots() =>
        await FindAll().ToListAsync();

    public async Task<IEnumerable<MaterialVendorLot>> GetVendorLotsByMaterialNumber(int materialNumber) =>
        await FindByCondition(m => m.MaterialNumber == materialNumber).ToListAsync();

    public async Task<MaterialVendorLot> GetVendorLotByLotNumber(string lotNumber) =>
        await FindByCondition(l => l.VendorLotNumber == lotNumber).FirstOrDefaultAsync()
        ?? throw new VendorLotNotFoundException(lotNumber);

    public async Task<MaterialVendorLot> GetVendorLot(string lotNumber, int batchNumber) =>
        await FindByCondition(v => v.VendorLotNumber == lotNumber && v.BatchNumber == batchNumber).FirstOrDefaultAsync();
}