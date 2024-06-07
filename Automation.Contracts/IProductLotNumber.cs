namespace Automation.Contracts;
public interface IProductLotNumber
{
    Task<string> GetInitialLotNumber(int materialNumber);
    Task<string> UpdateLotNumber(string lotNumber);
    Task<string> GetLastLotNumber(int materialNumber);
}
