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
                LotId = 1,
                VendorLotNumber = "123-123-123",
                BatchNumber = 3214321,
                Quantity = 3,
                MaterialNumber = 324123,
            },
            new()
            {
                LotId = 2,
                VendorLotNumber = "Reclaim",
                BatchNumber = 0,
                Quantity = 2,
                MaterialNumber = 3209876,
            },
            new()
            {
                LotId = 3,
                VendorLotNumber = "123-123-123",
                BatchNumber = 3214322,
                Quantity = 4,
                MaterialNumber = 324123,
            },
            new()
            {
                LotId = 3,
                VendorLotNumber = "BRI-2345",
                BatchNumber = 1231234,
                Quantity = 4,
                MaterialNumber = 451771
            }
        };
    }
}