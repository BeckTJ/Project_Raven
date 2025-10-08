namespace Services.Contracts;

public interface IProductLotNumber
{
    string GetProductLotNumber(int materialNumber);
    Task<string> UpdateLotNumber(string lotNumber);
}
