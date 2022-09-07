using Application.Interfaces;
using AutoMapper;
using CoNettion.Core.Exceptions;
using Domain.Http.GoodsReceivedNotes;
using FluentValidation;
using MediatR;
using CoNettion.Core.Exceptions;
using Domain.Entities.GoodsReceivedNotes;

namespace Application.Features.GoodReceivedNotes.Commands;

public class UpdateGoodsReceivedNoteCommand
{
    public class Validator : AbstractValidator<UpdateGoodsReceivedNoteStatusRequest>
    {
        public Validator() : base()
        {
            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }

    public class Handler : IRequestHandler<UpdateGoodsReceivedNoteStatusRequest, UpdateGoodsReceivedNoteStatusResponse>
    {
        private readonly IGoodsReceivedNotesRepository _goodReceivedNotesRepository;
        private readonly IMapper _mapper;

        public Handler(IGoodsReceivedNotesRepository goodReceivedNotesRepository, IMapper mapper)
        {
            _goodReceivedNotesRepository = goodReceivedNotesRepository;
            _mapper = mapper;
        }

        public async Task<UpdateGoodsReceivedNoteStatusResponse> Handle(UpdateGoodsReceivedNoteStatusRequest request, CancellationToken cancellationToken)
        {
            var goodReceivedNote = await _goodReceivedNotesRepository.GetByIdAsync<GoodsReceivedNote>(request.Id, cancellationToken);

            if (goodReceivedNote == null)
            {
                throw new NotFoundException();
            }

            goodReceivedNote.GrnStatus = request.Status;

            var returnedGoodReceivedNote = await _goodReceivedNotesRepository.UpdateStatusAsync(goodReceivedNote, cancellationToken);

            return returnedGoodReceivedNote;
        }
    }
}