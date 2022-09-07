using AutoFixture;
using ConNetionApiTests.Customizations;
using ConNetionApiTests.Infrastructure;
using Domain.Entities.GoodsReceivedNotes;
using System;
using System.Collections.Generic;
using Xunit;

namespace ConNetionApiTests.Features.GoodsReceivedNotes.GetGoodReceivedNoteByIdQueryTests;

[CollectionDefinition(nameof(GetGoodReceivedNoteByIdCollection))]
public class GetGoodReceivedNoteByIdCollection : ICollectionFixture<GetGoodReceivedNoteByIdTestsFixture>
{

}

public class GetGoodReceivedNoteByIdTestsFixture : BaseTestFixture
{
    public static readonly Guid GoodReceivedNoteId = Guid.NewGuid();

    public static readonly Guid GoodReceivedNoteAddressId = Guid.NewGuid();

    public static readonly Guid GoodReceivedNoteCargoId = Guid.NewGuid();

    public GetGoodReceivedNoteByIdTestsFixture()
    {
        SetupGoodsReceivedNotes();
        SetupGoodsReceivedNotesAddress();
    }

    private void SetupGoodsReceivedNotesCargo()
    {
        var goodsReceivedNoteCargo = new Fixture()
            .Create<GoodsReceivedNoteCargo>();

        goodsReceivedNoteCargo.Id = GoodReceivedNoteCargoId;
        goodsReceivedNoteCargo.GoodReceivedNoteId = GoodReceivedNoteId;

        Context.AddRange(goodsReceivedNoteCargo);
        Context.SaveChanges();
    }


    private void SetupGoodsReceivedNotesAddress()
    {
        var goodsReceivedNoteAddress = new Fixture()
            .Create<GoodsReceivedNoteAddress>();

        goodsReceivedNoteAddress.Id = GoodReceivedNoteAddressId;

        Context.AddRange(goodsReceivedNoteAddress);
        Context.SaveChanges();
    }

    private void SetupGoodsReceivedNotes()
    {
        var goodsReceivedNote = new Fixture()
            .Customize(new GoodReceivedNoteCustomization())
            .Create<GoodsReceivedNote>();

        goodsReceivedNote.Id = GoodReceivedNoteId;
        goodsReceivedNote.GoodReceivedNoteAddressId = GoodReceivedNoteAddressId;

        var cargo = new Fixture()
            .Create<GoodsReceivedNoteCargo>();

        cargo.Id = GoodReceivedNoteCargoId;
        goodsReceivedNote.GrnCargoes = new List<GoodsReceivedNoteCargo>(){cargo};

        Context.AddRange(goodsReceivedNote);
        Context.SaveChanges();
    }
}