using Domain.Entities.Users;
using Domain.Http.User;
using MediatR;
using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<User> GetUserByUsernameAsync(string username);
    Task<IQueryable<User>> GetUserListAsync(IEnumerable<Expression<Func<User, bool>>> filters, Expression<Func<User, bool>> orderBy, CancellationToken cancellationToken);
    Task<User> AddUserAsync(User entity, CancellationToken cancellationToken);
    Task<User> UpdateUserAsync(User entity, CancellationToken cancellationToken);
    Task<Unit> DeleteUserAsync(User entity, CancellationToken cancellationToken);
}