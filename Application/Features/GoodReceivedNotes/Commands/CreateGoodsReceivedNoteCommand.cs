using Application.Interfaces;
using AutoMapper;
using CoNettion.Core.Enums;
using Domain.Http.GoodsReceivedNotes;
using FluentValidation;
using MediatR;

namespace Application.Features.GoodReceivedNotes.Commands;

public class CreateGoodsReceivedNoteCommand
{
    public class Validator : AbstractValidator<CreateGoodsReceivedNoteRequest>
    {
        public Validator() : base()
        {
            RuleFor(x => x.GrnNumber)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.GrnDate)
                .NotEmpty();

            RuleFor(x => x.DocumentDate)
                .NotEmpty();

            RuleFor(x => x.ImportNumber)
                .MaximumLength(50);

            RuleFor(x => x.NumberFromWms)
                .MaximumLength(50);

            RuleFor(x => x.Description)
                .MaximumLength(250);

            RuleFor(x => x.WarehouseDescription)
                .MaximumLength(250);

            RuleFor(x => x.AdditionalInformation)
                .MaximumLength(250);

            RuleFor(x => x.CourierName)
                .MaximumLength(50);

            RuleFor(x => x.TrackingNumber)
                .MaximumLength(50);

            RuleForEach(x => x.Cargoes).NotNull()
                .ChildRules(x => x.RuleFor(x => x.CargoName).NotEmpty().MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(0))
                .ChildRules(x => x.RuleFor(x => x.Sku).NotEmpty().MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.Description).MaximumLength(250))
                .ChildRules(x => x.RuleFor(x => x.UnitOfMeasurment).IsInEnum())
                .ChildRules(x => x.RuleFor(x => x.UnitOfWeight).IsInEnum());

            RuleFor(x => x.Address).NotEmpty()
                .ChildRules(x => x.RuleFor(x => x.City).NotEmpty().MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.Country).IsInEnum())
                .ChildRules(x => x.RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress())
                .ChildRules(x => x.RuleFor(x => x.HouseNumber).NotEmpty().MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.Street).NotEmpty().MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.Phone).NotEmpty().MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.CompanyName).MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.FirstName).MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.LastName).MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.TaxNumber).MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.LocalNumber).MaximumLength(50))
                .ChildRules(x => x.RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(50).Matches(@"^[0-9]+$"));
        }
    }
    public class Handler : IRequestHandler<CreateGoodsReceivedNoteRequest, CreateGoodsReceivedNoteResponse>
    {
        private readonly IGoodsReceivedNotesRepository _goodReceivedNotesRepository;
        private readonly IMapper _mapper;

        public Handler(IGoodsReceivedNotesRepository goodReceivedNotesRepository, IMapper mapper)
        {
            _goodReceivedNotesRepository = goodReceivedNotesRepository;
            _mapper = mapper;
        }

        public async Task<CreateGoodsReceivedNoteResponse> Handle(CreateGoodsReceivedNoteRequest request, CancellationToken cancellationToken)
        {
            var goodReceivedNote = await _goodReceivedNotesRepository.AddAsync(request, cancellationToken);

            var returnedGoodReceivedNote = _mapper.Map<CreateGoodsReceivedNoteResponse>(goodReceivedNote);

            return returnedGoodReceivedNote;
        }
    }
} 