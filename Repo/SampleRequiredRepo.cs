using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;

namespace Repo;

internal sealed class SampleRequiredRepo : RepoBase<SampleRequired>, ISampleRequiredRepo
{
    public SampleRequiredRepo(ravenContext ctx) : base(ctx) { }
    public async Task<IEnumerable<SampleRequired>> GetAllSampleRequired() =>
        await FindAll().ToListAsync();

    public async Task<IEnumerable<SampleRequired>> GetSampleRequiredByMaterialNumber(int materialNumber) =>
        await FindByCondition(m => m.MaterialNumber == materialNumber).ToListAsync();
}