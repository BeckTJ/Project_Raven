
using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;
using shared.Exceptions;

namespace Repo;

internal sealed class SampleStatusRepo : RepoBase<SampleStatus>, ISampleStatusRepo
{
    public SampleStatusRepo(ravenContext ctx) : base(ctx) { }

    public async Task<IEnumerable<SampleStatus>> GetAllSampleStatus() =>
        await FindAll().ToListAsync();
    public async Task<SampleStatus> GetSampleStatusBySampleId(int sampleId) =>
        await FindByCondition(id => id.SampleId == sampleId).FirstOrDefaultAsync()
        ?? throw new SampleNotFoundException(sampleId);
}