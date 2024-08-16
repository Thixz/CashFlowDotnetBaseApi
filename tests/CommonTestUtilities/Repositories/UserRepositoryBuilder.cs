using CashFlow.Domain.Repositories.Users;
using Moq;

namespace CommonTestUtilities.Repositories;
public class UserRepositoryBuilder
{
    private readonly Mock<IUsersRepository> _repository;

    public UserRepositoryBuilder()
    {
        _repository = new Mock<IUsersRepository>();
    }

    public void ExistActiveUserWithEmail(string email)
    {
        _repository.Setup(userReadOnly => userReadOnly.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
    }

    public IUsersRepository Build() => _repository.Object;
}
