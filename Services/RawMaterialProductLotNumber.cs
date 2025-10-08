using shared.Exceptions;
using Repo.Contracts;
using shared.DTO;
using AutoMapper;

namespace Services;

internal sealed class RawMaterialLotNumber
{
    private readonly IRepoManager _repo;
    private readonly IMapper _map;

    public RawMaterialLotNumber(IRepoManager repo, IMapper map)
    {
        _repo = repo;
        _map = map;
    }
    public static string GetProductLotNumber(VendorWithLogsDTO material)
    {
        var rawMaterial = material.RawMaterial.OrderByDescending(m => m.ProductLotNumber).FirstOrDefault();

        if (rawMaterial is null)
            return material.SequenceId + material.MaterialCode;
        else
            return GetNextLotNumber(rawMaterial.ProductLotNumber, material.MaterialCode);
    }
    private static string GetNextLotNumber(string lastLotNumber, string code)
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
        var dateCode = await _repo.DateCode.GetDateCode(currentMonth);
        var updatedLotNumber = lotNumber + currentYear + dateCode.DateCode1 + currentDay;
        return updatedLotNumber;
    }
}