namespace Repo.Contracts;
public interface IProductLotNumber
{
    Task<string> GetProductLotNumber(int materialNumber);
    Task<string> UpdateLotNumber(string lotNumber);
}
