namespace CashFlow.Application.UseCases.Expenses.Delete;
public interface IDeleteExpense
{
    Task Execute(long id);
}
