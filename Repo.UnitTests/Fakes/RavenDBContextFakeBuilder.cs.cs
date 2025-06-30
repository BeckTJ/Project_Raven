
using Entities;

namespace Repo.UnitTests.Fakes;

public class RavenDBContextFakeBuilder
{
    private List<RawMaterialLog>? rawMaterialLogs;

    public static List<RawMaterialLog> RawMaterialLogFake()
    {
        return new List<RawMaterialLog>()
        {
            new()
            {
                ProductLotNumber = "4000AA5J27",
                ContainerNumber = null,
                IssueDate = new DateTime(2024,05,03),
                NetWeight = 180,
                MaterialNumber = 451771,
                Lot = new()
                {
                    VendorLotNumber = "12-123-1234",
                    BatchNumber = 1231234,
                }
            },
            new()
            {
                ProductLotNumber = "4001AA5J27",
                ContainerNumber = null,
                IssueDate = new DateTime(2024,05,03),
                NetWeight = 180,
                MaterialNumber = 451771,
                Lot = new()
                {
                    VendorLotNumber = "12-123-1234",
                    BatchNumber = 1231234,
                }
            },
            new()
            {
                ProductLotNumber = "4003AA5J27",
                ContainerNumber = null,
                SampleId = 987655,
                IssueDate = new DateTime(2025,10,10),
                NetWeight = 180,
                MaterialNumber = 23023456,
                Lot = new()
                {
                    VendorLotNumber = "Reclaim",
                    BatchNumber = 4324321,
                }
            }
        };
    }
    public static IEnumerable<MaterialVendorLot> VendorLotFake()
    {
        return new List<MaterialVendorLot>()
        {
            new()
            {
                LotId = 123,
                VendorLotNumber = "123-12-1234",
                BatchNumber = 3211234,
                Quantity = 6,
                MaterialNumber = 451771,
            },
            new()
            {
                LotId= 234,
                VendorLotNumber = "Reclaim",
                BatchNumber = 4321234,
                Quantity = 2,
                MaterialNumber = 23023456,
            },
            new()
            {
                LotId = 124,
                VendorLotNumber = "123-12-1234",
                BatchNumber = 3211235,
                Quantity = 3,
                MaterialNumber = 451771,
            }
        };
    }
}