using shared.Exceptions;
using Repo.Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repo;

internal sealed class RawMaterialLotNumber : IProductLotNumber
{
    private readonly ravenContext _ctx;

    public RawMaterialLotNumber(ravenContext ctx)
    {
        _ctx = ctx;
    }
    public async Task<string> GetProductLotNumber(int materialNumber)
    {
        var material = await _ctx.RawMaterialVendors.FirstAsync(x => x.MaterialNumber == materialNumber)
            ?? throw new MaterialNotFoundException(materialNumber);
        var rawMaterial = material.RawMaterialLogs.OrderByDescending(m => m.ProductLotNumber).FirstOrDefault();

        if (rawMaterial is null)
            return material.SequenceId + material.MaterialCode;
        else
            return GetNextLotNumber(rawMaterial.ProductLotNumber, material.MaterialCode);
    }
    private string GetNextLotNumber(string lastLotNumber, string code)
    {
        int id = 0;
        if (lastLotNumber.Length == 10)
            id = int.Parse(lastLotNumber[..4]) + 1;
        if (lastLotNumber.Length == 9)
            id = int.Parse(lastLotNumber[..3]) + 1;

        return id + code;
    }
    public async Task<string> UpdateLotNumber(string lotNumber)
    {
        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year % 10;
        var currentDay = DateTime.Now.Day;
        var dateCode = await _ctx.DateCodes.FirstAsync(x => x.DateId == currentMonth);
        var updatedLotNumber = lotNumber + currentYear + dateCode.DateCode1 + currentDay;
        return updatedLotNumber;
    }
}