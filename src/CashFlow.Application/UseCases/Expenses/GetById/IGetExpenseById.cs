using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.GetById;
public interface IGetExpenseById
{
    Task<ResponseExpenseJson> Execute(long id);
}
