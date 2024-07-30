namespace CashFlow.Communication.Responses;
public class ResponseExpensesJson
{
    public List<ResponseShortExpenseJson> Expenses { get; set; } = [];
}
public class ResponseShortExpenseJson
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
