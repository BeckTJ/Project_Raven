using Entities;

namespace Repo.Contracts;

public interface ISampleRequiredRepo
{
    public Task<IEnumerable<SampleRequired>> GetAllSampleRequired();
    public Task<IEnumerable<SampleRequired>> GetSampleRequiredByMaterialNumber(int materialNumber);
}