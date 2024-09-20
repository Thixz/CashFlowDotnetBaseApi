using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Domain.Entities;
using CommonTestUtilities.LoggedUser;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;

namespace WebApi.test.Expenses.GetById;
public class GetExpenseByIdUseCaseTest
{

    private GetExpenseByIdUseCase CreateUseCase(User user, Expense? expense = null)
    {
        var repository = new ExpensesRepositoryBuilder().GetById(user,expense).Build();
        var mapper = MapperBuilder.Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new GetExpenseByIdUseCase(repository, mapper, loggedUser);
    }
}
