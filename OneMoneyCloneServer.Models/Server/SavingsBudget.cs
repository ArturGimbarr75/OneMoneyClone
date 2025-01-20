namespace OneMoneyCloneServer.Models;

public sealed class SavingsBudget : BudgetBase
{
	public decimal AmountInMainCurrency { get; set; }
	public Guid AccountId { get; set; }
	public Account Account { get; set; } = default!;
}