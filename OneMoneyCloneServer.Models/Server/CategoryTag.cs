namespace OneMoneyCloneServer.Models.Server;

public sealed class CategoryTag : CreationTrackingEntity
{
	public Guid Id { get; set; }
	public required string Name { get; set; }
	public Guid CategoryId { get; set; }
	public Category Category { get; set; } = default!;

	public ICollection<Transaction> Transactions { get; set; } = [];
	public ICollection<TagBudget> TagBudgets { get; set; } = [];
}
