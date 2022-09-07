using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.GoodsReceivedNotes;
using Domain.Http.GoodsReceivedNotes;
using Domain.Http.GoodsReceivedNotes.Dto;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GoodsReceivedNotesRepository : IGoodsReceivedNotesRepository
{
    private readonly IMapper _mapper;
    private readonly CoNettionDbContext _dbContext;

    public GoodsReceivedNotesRepository(IMapper mapper, CoNettionDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    public async Task<T> GetByIdAsync<T>(Guid Id, CancellationToken cancellationToken)
    {
        return await _dbContext.GoodsReceivedNotes
            .Where(x => x.Id == Id)
            .ProjectTo<T>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<UpdateGoodsReceivedNoteStatusResponse> UpdateStatusAsync(GoodsReceivedNote entity, CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);

        var goodsReceivedNote = _mapper.Map<UpdateGoodsReceivedNoteStatusResponse>(entity);

        return goodsReceivedNote;
    }

    public async Task<GoodsReceivedNote> AddAsync(CreateGoodsReceivedNoteRequest entity, CancellationToken cancellationToken)
    {
        var goodReceivedNote = _mapper.Map<GoodsReceivedNote>(entity);

        await _dbContext.GoodsReceivedNotes.AddAsync(goodReceivedNote, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return goodReceivedNote;
    }
}