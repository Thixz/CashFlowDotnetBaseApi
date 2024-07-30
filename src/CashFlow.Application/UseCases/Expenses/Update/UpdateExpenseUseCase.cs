using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Update;
public class UpdateExpenseUseCase : IUpdateExpense
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateExpenseUseCase(IExpensesRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id, RequestExpenseJson request)
    {
        Validate(request);

        var expense = await _repository.GetByIdTracking(id);
        if (expense is null)
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);

        _mapper.Map(request, expense);

        _repository.Update(expense);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestExpenseJson request)
    {
        var validationResult = new ExpenseValidator().Validate(request);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
