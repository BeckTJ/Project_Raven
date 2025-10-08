namespace shared.DTO;

public record RawMaterialInputDTO
{
    public string ProductLotNumber { get; set; } = null!;
    public string? ContainerNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public int? NetWeight { get; set; }
    public int MaterialNumber { get; set; }
    public int LotId { get; set; }
    //public int SampleId { get; set; }
}