
using Entities;
using shared.DTO;

namespace Repo.UnitTests.Fakes;

public static class RawMaterialLogFakeBuilder
{
    public static IEnumerable<RawMaterialLog> RawMaterialLogFake()
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
                },
                Sample = new SampleStatus()
                    {
                        SampleId = 987655,
                        SampleType = "Raw",
                        InspectionLotNumber = 99999123123,
                        SubmitDate = new DateTime(2025,10,10),
                        Approved = true,
                        Rejected = false,
                        StatusDate = new DateTime(2024,10,15),
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
                },
                Sample = new SampleStatus()
                    {
                        SampleId = 987655,
                        SampleType = "Raw",
                        InspectionLotNumber = 99999123123,
                        SubmitDate = new DateTime(2025,10,10),
                        Approved = true,
                        Rejected = false,
                        StatusDate = new DateTime(2024,10,15),
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
                },
                Sample = new SampleStatus()
                    {
                        SampleId = 987654,
                        SampleType = "Raw",
                        InspectionLotNumber = null,
                        SubmitDate = new DateTime(2024,05,03),
                        Approved = true,
                        Rejected = false,
                        StatusDate = new DateTime(2024,05,05),
                    }
            }
        };
    }
}