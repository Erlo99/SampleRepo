using CoNettion.Core.Enums;

namespace Domain.Http.GoodsReceivedNotes.Dto;

public class CreateGoodsReceivedNoteAddressDto
{
    public string CompanyName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string LocalNumber { get; set; }
    public string City { get; set; }
    public CountryEnum Country { get; set; }
    public string ZipCode { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string TaxNumber { get; set; }
}