using MediatR;

namespace Domain.Http.GoodsReceivedNotes;

public class GetGoodsReceivedNoteByIdQueryRequest : IRequest <GetGoodsReceivedNoteByIdQueryResponse>
{
    public Guid Id { get; set; }
}