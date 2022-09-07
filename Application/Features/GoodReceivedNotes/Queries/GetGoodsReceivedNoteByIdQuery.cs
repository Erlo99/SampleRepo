using Application.Interfaces;
using CoNettion.Core.Exceptions;
using Domain.Http.GoodsReceivedNotes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.GoodReceivedNotes.Queries;

public class GetGoodsReceivedNoteByIdQuery
{
    public class Handler : IRequestHandler<GetGoodsReceivedNoteByIdQueryRequest, GetGoodsReceivedNoteByIdQueryResponse>
    {
        private readonly IGoodsReceivedNotesRepository _goodReceivedNotesRepository;

        public Handler(IGoodsReceivedNotesRepository goodReceivedNotesRepository)
        {
            _goodReceivedNotesRepository = goodReceivedNotesRepository;
        }
        public async Task<GetGoodsReceivedNoteByIdQueryResponse> Handle(GetGoodsReceivedNoteByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var goodReceivedNote = await _goodReceivedNotesRepository.GetByIdAsync<GetGoodsReceivedNoteByIdQueryResponse>(request.Id, cancellationToken);
            
            if (goodReceivedNote == null)
            {
                throw new NotFoundException();
            }

            return goodReceivedNote;
        }
    }
}