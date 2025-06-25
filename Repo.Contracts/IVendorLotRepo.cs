
using Entities;

namespace Repo.Contracts;

public interface IVendorLotRepo
{
    public Task<IEnumerable<MaterialVendorLot>> GetAllVendorLots();
    Task<MaterialVendorLot> GetVendorLotByLotNumber(string vendorLot);
    public Task<IEnumerable<MaterialVendorLot>> GetVendorLotsByMaterialNumber(int materialNumber);

}