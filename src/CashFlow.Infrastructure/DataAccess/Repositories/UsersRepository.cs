using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class UsersRepository : IUsersRepository
{
    private readonly CashFlowDbContext _dbContext;
    public UsersRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }
    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AsNoTracking().AnyAsync(user => user.Email == email);
    }

    public async Task<User> GetById(long id)
    {
        return await _dbContext.Users.FirstAsync(user => user.Id == id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email == email);
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}
