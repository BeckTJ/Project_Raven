using NSubstitute;
using Repo.Contracts;
using Services.Contracts;

namespace RavenAPI.UnitTests;

public class RawMaterialInputTests
{
    private IServiceManager _sut;
    private readonly IRepoManager _repo = Substitute.For<IRepoManager>();

}