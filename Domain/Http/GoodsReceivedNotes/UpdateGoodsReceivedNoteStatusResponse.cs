using CoNettion.Core.Enums;
using Domain.Entities.Common;
using Domain.Http.GoodsReceivedNotes.Dto;

namespace Domain.Http.GoodsReceivedNotes;

public class UpdateGoodsReceivedNoteStatusResponse
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
    public GoodsReceivedNoteStatusEnum Status { get; set; }
}