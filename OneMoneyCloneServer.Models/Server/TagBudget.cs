namespace OneMoneyCloneServer.Models.Server;

public sealed class TagBudget : BudgetBase
{
	public Guid TagId { get; set; }
	public CategoryTag CategoryTag { get; set; } = default!;
}