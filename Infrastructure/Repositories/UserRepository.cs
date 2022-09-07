using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Users;
using Domain.Http.User;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CoNettionDbContext _dbContext;

    public UserRepository(CoNettionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(x => x.UserName == username);
    }

    public async Task<User> GetUserByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == Id, cancellationToken);
    }

    public async Task<IQueryable<User>> GetUserListAsync(IEnumerable<Expression<Func<User, bool>>> filters, Expression<Func<User, bool>> orderBy, CancellationToken cancellationToken)
    {
        var userList = _dbContext.Users.AsQueryable();

        foreach (var filter in filters)
            userList = userList.Where(filter);

        if (orderBy != null)
            userList.OrderBy(orderBy);   

        return userList;
    }

    public async Task<User> UpdateUserAsync(User entity, CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<User> AddUserAsync(User entity, CancellationToken cancellationToken)
    {
        await _dbContext.Users.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
    
    public async Task<Unit> DeleteUserAsync(User entity, CancellationToken cancellationToken)
    {
        _dbContext.Users.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}