
using Entities;

namespace Repo.Contracts;

public interface IVendorLotRepo
{
    public Task<IEnumerable<MaterialVendorLot>> GetAllVendorLots();
    Task<MaterialVendorLot> GetVendorLot(string lotNumber, int batchNumber);
    Task<MaterialVendorLot> GetVendorLotByLotNumber(string vendorLot);
    public Task<IEnumerable<MaterialVendorLot>> GetVendorLotsByMaterialNumber(int materialNumber);

}