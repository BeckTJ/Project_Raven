using Entities;

namespace Services.UnitTests.Fakes;

public static class VendorLotFakeBuilder
{
    public static IEnumerable<MaterialVendorLot> VendorLotFake()
    {
        return new List<MaterialVendorLot>()
        {
            new()
            {
                LotId = 123,
                VendorLotNumber = "123-123-123",
                BatchNumber = 3214321,
                Quantity = 3,
                MaterialNumber = 324123,
            },
            new()
            {
                LotId = 231,
                VendorLotNumber = "Reclaim",
                BatchNumber = null,
                Quantity = 2,
                MaterialNumber = 3209876,
            },
            new()
            {
                LotId = 235,
                VendorLotNumber = "123-123-123",
                BatchNumber = 3214322,
                Quantity = 4,
                MaterialNumber = 324123,
            }
        };
    }
}