using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;
public interface IExpensesRepository
{
    Task Add(Expense expense);
    Task<List<Expense>> GetAll();
    Task<Expense?> GetById(long id);
    Task<Expense?> GetByIdTracking(long id);
    Task<List<Expense>> GetByFilteringMonth(DateOnly date);
    /// <summary>
    /// This function returns TRUE if the deletion process was successful otherwise returns FALSE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
    void Update (Expense expense);
}
