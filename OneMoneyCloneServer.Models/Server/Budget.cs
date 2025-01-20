namespace OneMoneyCloneServer.Models.Server;

public sealed class Budget : BudgetBase
{
	public Guid CategoryId { get; set; }
	public Category Category { get; set; } = default!;
}
