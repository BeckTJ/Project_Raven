namespace shared.DTO;

public record RawMaterialSampleDTO
{
    public RawMaterialDTO? RawMaterialDrum { get; set; }
    public RequiredSampleDTO? SampleRequired { get; set; }
}