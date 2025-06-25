
using Entities;

namespace Repo.Contracts;

public interface ISampleStatusRepo
{
    Task<IEnumerable<SampleStatus>> GetAllSampleStatus();
    Task<SampleStatus> GetSampleStatusBySampleId(int sampleId);
}