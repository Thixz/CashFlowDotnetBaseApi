using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class ExpensesRepository : IExpensesRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);
        if (result is null)
        {
            return false;
        }

        _dbContext.Expenses.Remove(result);

        return true;
    }

    public async Task<List<Expense>> GetAll()
    {
        return await _dbContext.Expenses.AsNoTracking().ToListAsync(); // As no tracking evita que as entidades fiquem em cache que fica olhando se elas serão alteradas. Como aqui temos ctz que não iremos alterar na regra de negócio as informações podemos usar as no tracking.
    }

    public async Task<List<Expense>> GetByFilteringMonth(DateOnly date)
    {
        var startDate = new DateTime(date.Year, date.Month, day: 1).Date;

        var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
        var endDate = new DateTime(date.Year, date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

        return await _dbContext.Expenses
            .AsNoTracking()
            .Where(expense => expense.Date >= startDate && expense.Date <= endDate)
            .OrderByDescending(expense => expense.Date) // orderna por data maior para menor
            .ThenBy(expense => expense.Title) // E então por titulo caso haja dois gastos com mesma data
            .ToListAsync();
    }

    public async Task<Expense?> GetById(long id)
    {
        return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(expense => expense.Id == id);
    }

    public async Task<Expense?> GetByIdTracking(long id)
    {
        return await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);
    }

    public void Update(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }
}
