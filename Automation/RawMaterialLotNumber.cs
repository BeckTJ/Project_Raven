using Automation.Contracts;
using shared.Exceptions;
using Repo.Contracts;

namespace Automation;

internal sealed class RawMaterialLotNumber : IProductLotNumber
{
    private readonly IRepoManager _repo;

    public RawMaterialLotNumber(IRepoManager repo)
    {
        _repo = repo;
    }
    public async Task<string> GetInitialLotNumber(int materialNumber)
    {
        var material = await _repo.VendorRepo.GetVendorByMaterialNumber(materialNumber)
            ?? throw new MaterialNotFoundException(materialNumber);

        return material.SequenceId + material.MaterialCode;
    }

    public async Task<string> UpdateLotNumber(string lotNumber)
    {
        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year % 10;
        var currentDay = DateTime.Now.Day;
        var dateCode = await _repo.DateCode.GetDateCode(currentMonth);
        var updatedLotNumber = lotNumber + currentYear + dateCode.DateCode1 + currentDay;
        return updatedLotNumber;
    }
    public async Task<string> GetLastLotNumber(int materialNumber)
    {
        var material = await _repo.RawMaterial.GetRawMaterialByMaterialNumber(materialNumber) ?? throw new RawMaterialNotFoundException(materialNumber);
        
        var rawMaterial = material.OrderByDescending(m => m.ProductLotNumber).First();

        return rawMaterial.ProductLotNumber;

    }
}
