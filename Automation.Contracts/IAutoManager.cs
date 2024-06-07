namespace Automation.Contracts;

public interface IAutoManager
{
    public IProductLotNumber ProductLotNumber { get; }
    public IProductLotNumber RawMaterialLotNumber { get; }
}