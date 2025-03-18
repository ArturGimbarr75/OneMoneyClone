using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.DTO.Account;

public class AccountDto
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public decimal Balance { get; set; }
	public Guid CurrencyId { get; set; }
	public AccountType Type { get; set; }
}
