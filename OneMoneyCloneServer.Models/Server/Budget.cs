namespace OneMoneyCloneServer.Models;

public sealed class Budget : BudgetBase
{
	public Guid CategoryId { get; set; }
	public Category Category { get; set; } = default!;
}
