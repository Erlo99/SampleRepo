using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using CoNettion.Core.Enums;
using Domain.Common;
using Domain.Entities.Common;

namespace Domain.Entities.GoodsReceivedNotes;

public class GoodsReceivedNote : BaseClassEntity
{
    [Required]
    [MaxLength(50)]
    public string GrnNumber { get; set; }
    [Required]
    public DateTimeOffset GrnDate { get; set; }
    [MaxLength(50)]
    public string ImportNumber { get; set; }
    [MaxLength(50)]
    public string NumberFromWms { get; set; }
    [MaxLength(250)]
    public string Description { get; set; }
    [MaxLength(250)]
    public string WarehouseDescription { get; set; }
    [MaxLength(250)]
    public string AdditionalInformation { get; set; }
    [MaxLength(50)]
    public string CourierName { get; set; }
    [MaxLength(50)]
    public string TrackingNumber { get; set; }
    [Required]
    public DateTimeOffset DocumentDate { get; set; }
    public ICollection<GoodsReceivedNoteCargo> GrnCargoes { get; set; } = new HashSet<GoodsReceivedNoteCargo>();
    public GoodsReceivedNoteAddress GrnAddress { get; set; }
    public Guid GoodReceivedNoteAddressId { get; set; }
    public GoodsReceivedNoteStatusEnum GrnStatus { get; set; }
}