using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;

namespace Repo;

internal sealed class DateCodeRepo : RepoBase<DateCode>, IDateCode
{
    public DateCodeRepo(ravenContext ctx) : base(ctx) { }
    public async Task<DateCode> GetDateCode(int id) =>
        await FindByCondition(x => x.DateId == id).FirstAsync();

}