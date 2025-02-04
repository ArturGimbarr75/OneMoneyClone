namespace OneMoneyCloneServer.Models.Server;

public sealed class Currency
{
	public Guid Id { get; set; }
	public required string Name { get; set; }
	public required string Code { get; set; }
	public required int Decimals { get; set; }
	public required string Symbol { get; set; }

	public ICollection<Account> Accounts { get; set; } = [];
	public ICollection<Transaction> Transactions { get; set; } = [];
	public ICollection<User> Users { get; set; } = [];
}
