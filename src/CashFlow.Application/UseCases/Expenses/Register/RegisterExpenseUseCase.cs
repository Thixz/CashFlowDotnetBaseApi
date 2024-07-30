using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Expense>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredExpenseJson>(entity);
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
