using System.Text.Json.Serialization;
using CoNettion.Core.Enums;
using Domain.Entities.GoodsReceivedNotes;
using Domain.Http.GoodsReceivedNotes.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Domain.Http.GoodsReceivedNotes;

public class CreateGoodsReceivedNoteRequest : IRequest<CreateGoodsReceivedNoteResponse>
{
    public string GrnNumber { get; set; }
    public DateTimeOffset GrnDate { get; set; }
    public string ImportNumber { get; set; }
    public string NumberFromWms { get; set; }
    public string Description { get; set; }
    public string WarehouseDescription { get; set; }
    public string AdditionalInformation { get; set; }
    public string CourierName { get; set; }
    public string TrackingNumber { get; set; }
    public DateTimeOffset DocumentDate { get; set; }
    public List<CreateGoodsReceivedNoteCargoDto> Cargoes { get; set; } = new List<CreateGoodsReceivedNoteCargoDto>();
    public CreateGoodsReceivedNoteAddressDto Address { get; set; }
    [JsonIgnore] public GoodsReceivedNoteStatusEnum Status { get; set; } = GoodsReceivedNoteStatusEnum.NEW;
}