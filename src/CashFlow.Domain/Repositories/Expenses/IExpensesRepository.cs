using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;
public interface IExpensesRepository
{
    Task Add(Expense expense);
    Task<List<Expense>> GetAll(User user);
    Task<Expense?> GetById(User user, long id);
    Task<Expense?> GetByIdTracking(User user,long id);
    Task<List<Expense>> GetByFilteringMonth(User user,DateOnly date);
    /// <summary>
    /// This function returns TRUE if the deletion process was successful otherwise returns FALSE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task Delete(long id);
    void Update (Expense expense);
}
