using Domain.Entities.GoodsReceivedNotes;
using Domain.Http.GoodsReceivedNotes;

namespace Application.Interfaces;

public interface IGoodsReceivedNotesRepository
{
    Task<T> GetByIdAsync<T>(Guid Id, CancellationToken cancellationToken);
    Task<GoodsReceivedNote> AddAsync(CreateGoodsReceivedNoteRequest entity, CancellationToken cancellationToken);
    Task<UpdateGoodsReceivedNoteStatusResponse> UpdateStatusAsync(GoodsReceivedNote entity, CancellationToken cancellationToken);
}