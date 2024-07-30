using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Extensions;
public static class PaymentTypeExtensions
{
    public static string PaymentTypeToString(this PaymentType payment)
    {
        return payment switch
        {
            PaymentType.Cash => "Dinheiro",
            PaymentType.CreditCard => "Cartão de Crédito",
            PaymentType.DebitCard => "Cartão de Débito",
            PaymentType.EletronicTransfer => "Transferência Bancaria",
            _ => string.Empty
        };
    }
}
