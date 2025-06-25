
namespace shared.Exceptions;

public sealed class SampleNotFoundException : NotFoundException
{
    public SampleNotFoundException(int sampleId)
    : base($"The Vendor Lot {sampleId} was not found")
    { }
}