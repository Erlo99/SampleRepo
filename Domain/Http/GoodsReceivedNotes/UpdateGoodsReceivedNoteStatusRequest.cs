using CoNettion.Core.Enums;
using MediatR;

namespace Domain.Http.GoodsReceivedNotes;

public class UpdateGoodsReceivedNoteStatusRequest : IRequest<UpdateGoodsReceivedNoteStatusResponse>
{
    public Guid Id { get; set; }
    public GoodsReceivedNoteStatusEnum Status { get; set; }
}