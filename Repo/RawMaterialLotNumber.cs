using Repo.Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repo;

internal sealed class RawMaterialLotNumber : RepoBase<RawMaterialVendor>, IProductLotNumber
{
    public RawMaterialLotNumber(ravenContext ctx) : base(ctx)
    {
    }

    //need to create unit tests to figure out whats happening
    public async Task<string> GetProductLotNumber(int materialNumber)
    {
        var material = await FindByCondition(x => x.MaterialNumber == materialNumber).Include(m => m.RawMaterialLogs).FirstAsync();
        var rawMaterial = material.RawMaterialLogs.OrderByDescending(m => m.ProductLotNumber).FirstOrDefault();

        if (rawMaterial is null)
            return material.SequenceId + material.MaterialCode;
        else
            return GetNextLotNumber(rawMaterial.ProductLotNumber, material.MaterialCode);
    }
    private string GetNextLotNumber(string lastLotNumber, string code)
    {
        int id = 0;
        if (lastLotNumber.Length == 10 || lastLotNumber.Length == 6)
            id = int.Parse(lastLotNumber[..4]) + 1;
        if (lastLotNumber.Length == 9 || lastLotNumber.Length == 5)
            id = int.Parse(lastLotNumber[..3]) + 1;

        return id + code;
    }
    public async Task<string> UpdateLotNumber(string lotNumber)
    {
        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year % 10;
        var currentDay = DateTime.Now.ToString("dd");
        var dateCode = await _ctx.DateCodes.FirstAsync(x => x.DateId == currentMonth);
        var updatedLotNumber = lotNumber + currentYear + dateCode.DateCode1 + currentDay;
        return updatedLotNumber;
    }
}