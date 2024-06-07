
namespace shared.Exceptions;

public sealed class RawMaterialNotFoundException : NotFoundException
{
    public RawMaterialNotFoundException(int materialNumber)
        : base($"Raw material not found for {materialNumber}")
    { }
}