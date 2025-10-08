using Entities;

namespace Repo.UnitTests.Fakes;

public class VendorDBContextFakeBuilder
{
    private List<RawMaterialVendor>? materialVendors;

    public static List<RawMaterialVendor> MaterialVendorFake()
    {
        return new List<RawMaterialVendor>()
        {
            new()
            {
                MaterialNumber = 451771,
                VendorName = "GetNextLot",
                MaterialCode = "AR",
                BatchManaged = true,
                ContainerNumberRequired = false,
                SequenceId = 4000,
                TotalRecords = 1000,
                UnitOfIssue = "kg",
                ParentMaterialNumber = 45177,
                RawMaterialLogs = new List<RawMaterialLog>()
                {
                    new()
                    {
                        ProductLotNumber = "4000AR5J27",
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
                        ProductLotNumber = "4001AR5J27",
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
                        ProductLotNumber = "4002AR5J27",
                        ContainerNumber = null,
                        SampleId = 987655,
                        IssueDate = new DateTime(2025,10,10),
                        NetWeight = 180,
                        MaterialNumber = 23023456,
                        Lot = new()
                        {
                            VendorLotNumber = "12-123-9999",
                            BatchNumber = 1239999,
                        }
                    }
                }
            },
            new()
            {
                MaterialNumber = 12345,
                VendorName = "EmptyRMLog",
                MaterialCode = "BR",
                BatchManaged = true,
                ContainerNumberRequired = false,
                SequenceId = 500,
                TotalRecords = 100,
                UnitOfIssue = "kg",
                ParentMaterialNumber = 1234,
                RawMaterialLogs = new List<RawMaterialLog>()
                {

                }
            },
            new()
            {
                MaterialNumber = 991112,
                VendorName = "RestartSequenceId",
                MaterialCode = "CR",
                BatchManaged = true,
                ContainerNumberRequired = false,
                SequenceId = 100,
                TotalRecords = 100,
                UnitOfIssue = "kg",
                ParentMaterialNumber = 999111,
                RawMaterialLogs = new List<RawMaterialLog>()
                {
                    new()
                    {
                        ProductLotNumber = "197CR5J27",
                        ContainerNumber = null,
                        IssueDate = new DateTime(2024,05,03),
                        NetWeight = 180,
                        MaterialNumber = 991112,
                        Lot = new()
                        {
                            VendorLotNumber = "12-123-1234",
                            BatchNumber = 9971234,
                        }
                    },
                    new()
                    {
                        ProductLotNumber = "198CR5J27",
                        ContainerNumber = null,
                        IssueDate = new DateTime(2024,05,03),
                        NetWeight = 180,
                        MaterialNumber = 991112,
                        Lot = new()
                        {
                            VendorLotNumber = "12-123-1234",
                            BatchNumber = 9981234,
                        }
                    },
                    new()
                    {
                        ProductLotNumber = "199CR5J27",
                        ContainerNumber = null,
                        SampleId = 654321,
                        IssueDate = new DateTime(2025,10,10),
                        NetWeight = 180,
                        MaterialNumber = 991112,
                        Lot = new()
                        {
                            VendorLotNumber = "Reclaim",
                            BatchNumber = 9991234,
                        }
                    }
                }
            },
        };
    }
}