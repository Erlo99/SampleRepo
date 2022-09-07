namespace Domain.Http.GoodsReceivedNotes.Dto;

public class GoodsReceivedNoteCargoDto
{
    public Guid Id { get; set; }
    public string CargoName { get; set; }
    public string Sku { get; set; }
    public string Ean { get; set; }
    public string Description { get; set; }
    public string BatchNumber { get; set; }
    public string UnitOfMeasure { get; set; }
    public DateTimeOffset ExpirationDate { get; set; }
    public decimal Weight { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int ReceivedQuantity { get; set; }
    public int DestroyedQuantity { get; set; }
}