using AutoFixture;
using ConNetionApiTests.Customizations.Builders;
using Domain.Entities.GoodsReceivedNotes;

namespace ConNetionApiTests.Customizations;

public class GoodReceivedNoteCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Add(new IgnoreMembers(new []
        {
            nameof(GoodsReceivedNote.GrnAddress),
            nameof(GoodsReceivedNote.GrnStatus),
            nameof(GoodsReceivedNote.GrnCargoes)
        }));

    }
}