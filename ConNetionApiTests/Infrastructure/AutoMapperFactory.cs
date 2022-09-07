using System.Net.NetworkInformation;
using Application.Features.GoodReceivedNotes;
using AutoMapper;

namespace ConNetionApiTests.Infrastructure;

public static class AutoMapperFactory
{
    public static IMapper Create()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new GoodsReceivedNoteMapperProfile());
        });

        return mappingConfig.CreateMapper();
    }
}