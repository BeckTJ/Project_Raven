
using Entities;

namespace Repo.Contracts;

public interface IVendorLotRepo
{
    public Task<IEnumerable<MaterialVendorLot>> GetAllVendorLots();
    Task<MaterialVendorLot> GetVendorLot(string lotNumber, int? batchNumber);
    Task<MaterialVendorLot> GetVendorLotByLotNumber(string vendorLot);
    public Task<IEnumerable<MaterialVendorLot>> GetVendorLotsByMaterialNumber(int materialNumber);
    public void AddVendorLot(MaterialVendorLot materialVendorLot);
    public void UpdateVendorLot(MaterialVendorLot materialVendorLot);
    public void DeleteVendorLot(MaterialVendorLot materialVendorLot);
    public void SaveChanges();
}