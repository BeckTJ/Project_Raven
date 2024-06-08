using Automation.Contracts;
using Repo.Contracts;
using shared.Exceptions;

namespace Automation;
internal sealed class ProductLotNumber : IProductLotNumber
{
    private readonly IRepoManager _repo;
    public ProductLotNumber(IRepoManager repo)
    {
        _repo = repo;
    }
    public async Task<string> GetInitialLotNumber(int materialNumber)
    {
        var material = await _repo.MaterialRepo.GetMaterialByMaterialNumber(materialNumber);
        if (material is null)
            throw new MaterialNotFoundException(materialNumber);
        return material.SequenceId + material.MaterialCode;
    }

    public Task<string> GetLastLotNumber(int materialNumber)
    {
        throw new NotImplementedException();
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
}
