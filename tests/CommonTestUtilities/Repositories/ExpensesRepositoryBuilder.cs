using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Moq;

namespace CommonTestUtilities.Repositories;
public class ExpensesRepositoryBuilder
{
    private readonly Mock<IExpensesRepository> _repository;
    public ExpensesRepositoryBuilder()
    {
           _repository = new Mock<IExpensesRepository>();
    }

    public ExpensesRepositoryBuilder GetAll(User user, List<Expense> expenses)
    {
        _repository.Setup(repository => repository.GetAll(user)).ReturnsAsync(expenses);

        return this;
    }

    public ExpensesRepositoryBuilder GetById(User user, Expense? expense)
    {
        if(expense is not null)
        _repository.Setup(repository => repository.GetById(user,expense.Id)).ReturnsAsync(expense);

        return this;
    }

    public IExpensesRepository Build() => _repository.Object;
}
