using AutoMapper;
using CoNettion.Core.Enums;
using Domain.Entities.GoodsReceivedNotes;
using Domain.Http.GoodsReceivedNotes;
using Domain.Http.GoodsReceivedNotes.Dto;

namespace Application.Features.GoodReceivedNotes;

public class GoodsReceivedNoteMapperProfile : Profile
{
    public GoodsReceivedNoteMapperProfile()
    {
        CreateMap<GoodsReceivedNote, GetGoodsReceivedNoteByIdQueryResponse>()
            .ForMember(dest => dest.Status, src => src.MapFrom(x => x.GrnStatus));

        CreateMap<GoodsReceivedNoteAddress, GoodsReceivedNoteAddressDto>();

        CreateMap<GoodsReceivedNoteCargo, GoodsReceivedNoteCargoDto>();

        CreateMap<CreateGoodsReceivedNoteRequest, GoodsReceivedNote>()
            .ForMember(dest => dest.GrnAddress, src => src.MapFrom(x => x.Address))
            .ForMember(dest => dest.GrnCargoes, src => src.MapFrom(x => x.Cargoes))
            .ForMember(dest => dest.GrnStatus, src => src.MapFrom(x => x.Status));

        CreateMap<CreateGoodsReceivedNoteAddressDto, GoodsReceivedNoteAddress>()
            .ReverseMap();

        CreateMap<CreateGoodsReceivedNoteCargoDto, GoodsReceivedNoteCargo>()
            .ReverseMap();

        CreateMap<GoodsReceivedNote, CreateGoodsReceivedNoteResponse>()
            .ForMember(dest => dest.Address, src => src.MapFrom(x => x.GrnAddress))
            .ForMember(dest => dest.Cargoes, src => src.MapFrom(x => x.GrnCargoes))
            .ForMember(dest => dest.Status, src => src.MapFrom(x => x.GrnStatus));

        CreateMap<GoodsReceivedNote, UpdateGoodsReceivedNoteStatusResponse>()
            .ForMember(dest => dest.Status, src => src.MapFrom(x => x.GrnStatus.ToString()))
            .ForMember(dest => dest.Address, src => src.MapFrom(x => x.GrnAddress))
            .ForMember(dest => dest.Cargoes, src => src.MapFrom(x => x.GrnCargoes));

        CreateMap<GoodsReceivedNote, GoodsReceivedNote>();
    }
}