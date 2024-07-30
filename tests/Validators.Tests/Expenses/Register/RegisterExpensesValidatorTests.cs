using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpensesValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory] // Utilizado dessa forma para cnseguir passar parâmetros para a função de testes abaixo seja testado diversas vezes com parâmetros diferentes
    [InlineData("")]
    [InlineData("       ")]
    [InlineData(null)]
    public void Error_Title_Empty(string title)
    {
        // Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = title;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_IS_REQUIRED));
    }

    [Fact]
    public void Error_Date_Future()
    {
        // Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EXPENSE_CANNOTBE_FUTURE));
    }

    [Fact]
    public void Error_Invalid_PaymentType()
    {
        // Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)700;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.INVALID_PAYMENT_TYPE));
    }

    [Theory] // Utilizado dessa forma para cnseguir passar parâmetros para a função de testes abaixo seja testado diversas vezes com parâmetros diferentes
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-6)]
    public void Error_Invalid_Amount(decimal amount)
    {
        // Arrange
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_GREATER_ZERO));
    }
}
