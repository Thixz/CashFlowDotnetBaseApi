using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Users;
public interface IUsersRepository
{
    Task Add(User user);
    Task Delete(Entities.User user);
    Task<bool> ExistActiveUserWithEmail(string email);
    Task<User?> GetUserByEmail(string email);
    Task<User> GetById(long id);
    void Update(User user);
}
