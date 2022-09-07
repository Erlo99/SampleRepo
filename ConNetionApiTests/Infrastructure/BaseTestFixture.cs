using System;
using AutoMapper;
using Infrastructure.Data;

namespace ConNetionApiTests.Infrastructure;

public abstract class BaseTestFixture : IDisposable
{
    public CoNettionDbContext Context {get;}

    public IMapper Mapper { get; }

    public BaseTestFixture()
    {
        Context = DbContextFactory.Create();
        Mapper = AutoMapperFactory.Create();
    }
    public void Dispose()
    {
        DbContextFactory.Destroy(Context);
    }
}