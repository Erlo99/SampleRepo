using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace ConNetionApiTests.Infrastructure;

public static class DbContextFactory
{
    public static CoNettionDbContext Create()
    {
        var options = new DbContextOptionsBuilder<CoNettionDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new CoNettionDbContext(options, new Mock<ILogger<CoNettionDbContext>>().Object);

        context.Database.EnsureCreated();

        return context;
    }

    public static void Destroy(CoNettionDbContext context)
    {
        context.Database.EnsureDeleted();

        context.Dispose();
    }
}