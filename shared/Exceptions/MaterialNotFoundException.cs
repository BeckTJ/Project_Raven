
namespace shared.Exceptions;

public sealed class MaterialNotFoundException : NotFoundException
{
    public MaterialNotFoundException(int materialNumber)
        : base($"The material number {materialNumber} was not found")
    { }
}