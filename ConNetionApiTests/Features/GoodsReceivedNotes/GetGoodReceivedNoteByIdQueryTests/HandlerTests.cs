using System;
using System.Threading.Tasks;
using AutoFixture;
using Domain.Http.GoodsReceivedNotes;
using Infrastructure.Repositories;
using Xunit;
using Handler = Application.Features.GoodReceivedNotes.Queries.GetGoodsReceivedNoteByIdQuery.Handler;
using FluentAssertions;

namespace ConNetionApiTests.Features.GoodsReceivedNotes.GetGoodReceivedNoteByIdQueryTests;

[Collection(nameof(GetGoodReceivedNoteByIdCollection))]
public class HandlerTests
{
    private readonly Handler _handler;
    private readonly GetGoodReceivedNoteByIdTestsFixture _fixture;

    public HandlerTests(GetGoodReceivedNoteByIdTestsFixture fixture)
    {
        _fixture = fixture;

        var repo = new GoodsReceivedNotesRepository(fixture.Mapper, fixture.Context);

        _handler = new Handler(repo);
    }

    //[Fact]
    //public async Task GetGoodReceivedNoteById_WhenIdIsCorrect_Returns()
    //{
    //    var request = new Fixture().Create<GetGoodsReceivedNoteByIdQueryRequest>();

    //    request.Id = GetGoodReceivedNoteByIdTestsFixture.GoodReceivedNoteId;

    //    var response = await _handler.Handle(request, default);
    //    response.Should().NotBeNull();
    //}

    [Fact]
    public async Task GetGoodReceivedNoteById_WhenIdIsInCorrect_ThrowsException()
    {
        var request = new Fixture().Create<GetGoodsReceivedNoteByIdQueryRequest>();

        Func<Task> action = async () => await _handler.Handle(request, default);
        await action.Should().ThrowAsync<Exception>();
    }
}