namespace OneMoneyCloneServer.Models.Server;

public sealed class Category : CreationTrackingEntity
{
	public Guid Id { get; set; }
	public required string Name { get; set; }
	public Guid UserId { get; set; }
	public User User { get; set; } = default!;

	public ICollection<CategoryTag> CategoryTags { get; set; } = [];
	public ICollection<Transaction> Transactions { get; set; } = [];
	public ICollection<Budget> SavingsBudgets { get; set; } = [];
}
