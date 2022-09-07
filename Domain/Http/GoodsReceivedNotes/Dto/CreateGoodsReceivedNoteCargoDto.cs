using CoNettion.Core.Enums;

namespace Domain.Http.GoodsReceivedNotes.Dto;

public class CreateGoodsReceivedNoteCargoDto
{
    public string CargoName { get; set; }
    public string Sku { get; set; }
    public string Ean { get; set; }
    public string Description { get; set; }
    public string BatchNumber { get; set; }
    public UnitOfMeasurmentEnum UnitOfMeasurment{ get; set; }
    public UnitOfWeightEnum UnitOfWeight { get; set; }
    public DateTimeOffset ExpirationDate { get; set; }
    public decimal Weight { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}