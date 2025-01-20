namespace OneMoneyCloneServer.Models;

public sealed class Account : CreationTrackingEntity
{
	public Guid Id { get; set; }
	public required string Name { get; set; }
	public required decimal Balance { get; set; }
	public Guid CurrencyId { get; set; }
	public Currency Currency { get; set; } = default!;
	public Guid UserId { get; set; }
	public User User { get; set; } = default!;
	public AccountType Type { get; set; }

	public ICollection<Transaction> Transactions { get; set; } = [];
	public ICollection<SavingsBudget> SavingsBudgets { get; set; } = [];
}
