using Domain.Entities.GoodsReceivedNotes;
using Domain.Http.GoodsReceivedNotes.Dto;

namespace Domain.Http.GoodsReceivedNotes;

public class GetGoodsReceivedNoteByIdQueryResponse
{
    public Guid Id { get; set; }
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
    public string Status { get; set; }
    public IEnumerable<GoodsReceivedNoteCargoDto> GrnCargoes { get; set; } = new List<GoodsReceivedNoteCargoDto>();
    public GoodsReceivedNoteAddressDto GrnAddress { get; set; }
    
}