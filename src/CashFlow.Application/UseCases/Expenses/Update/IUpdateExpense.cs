using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Expenses.Update;
public interface IUpdateExpense
{
    Task Execute(long id, RequestExpenseJson request);
}
