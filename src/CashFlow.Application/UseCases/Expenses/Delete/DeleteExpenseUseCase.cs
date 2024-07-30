using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Delete;
public class DeleteExpenseUseCase : IDeleteExpense
{
    private readonly IExpensesRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
       var result = await _repository.Delete(id);

        if (result is false)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }
}
