
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
                VendorLotNumber = "12-123-1234",
                BatchNumber = 1231234,
                ContainerNumber = null,
                IssueDate = new DateTime(2024,05,03),
                NetWeight = 180,
                MaterialNumber = 451771,
            },
            new()
            {
                ProductLotNumber = "4001AA5J27",
                VendorLotNumber = "12-123-1234",
                BatchNumber = 1231234,
                ContainerNumber = null,
                IssueDate = new DateTime(2024,05,03),
                NetWeight = 180,
                MaterialNumber = 451771,
            },
            new()
            {
                ProductLotNumber = "4003AA5J27",
                VendorLotNumber = "Reclaim",
                BatchNumber = 4324321,
                ContainerNumber = null,
                SampleId = 987655,
                IssueDate = new DateTime(2025,10,10),
                NetWeight = 180,
                MaterialNumber = 23023456,
            }
        };
    }
}