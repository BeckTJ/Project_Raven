
namespace shared.Exceptions;

public sealed class NoSampleRequiredException : NotFoundException
{
    public NoSampleRequiredException(string vendorLotNumber)
        : base($"No sample is needed for : {vendorLotNumber}")
    { }
}