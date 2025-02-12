namespace OneMoneyCloneServer.Models.Server;

public sealed class Transaction : CreationTrackingEntity
{
	public Guid Id { get; set; }
	public required decimal Amount { get; set; }
	public required decimal AmountInMainCurrency { get; set; }
	public Guid CurrencyId { get; set; }
	public Currency Currency { get; set; } = default!;
	public string? Description { get; set; }
	public required DateTime Date { get; set; }
	public Guid? CategoryId { get; set; }
	public Category? Category { get; set; } = default!;
	public Guid AccountId { get; set; }
	public Account Account { get; set; } = default!;
	public TransactionType Type { get; set; }
	public Guid? TransferAccountId { get; set; }
	public Account? TransferAccount { get; set; }
	public decimal? AmountInAccountCurrency { get; set; }
}
