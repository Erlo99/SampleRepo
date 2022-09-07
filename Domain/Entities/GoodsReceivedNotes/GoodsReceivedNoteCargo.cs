using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Entities.Common;

namespace Domain.Entities.GoodsReceivedNotes;

public class GoodsReceivedNoteCargo : CargoEntity
{
    public Guid GoodReceivedNoteId { get; set; }
    [MaxLength(50)]
    public string BatchNumber { get; set; }
    public DateTimeOffset ExpirationDate { get; set; }
    public int ReceivedQuantity { get; set; }
    public int DestroyedQuantity { get; set; }
}