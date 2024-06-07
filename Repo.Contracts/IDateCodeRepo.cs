using Entities;

namespace Repo.Contracts;

public interface IDateCode
{
    public Task<DateCode> GetDateCode(int id);
}