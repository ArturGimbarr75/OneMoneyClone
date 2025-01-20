namespace OneMoneyCloneServer.Models.Server;

public sealed class TagBudget : BudgetBase
{
	public Guid CategoryTagId { get; set; }
	public CategoryTag CategoryTag { get; set; } = default!;
}