using Microsoft.AspNetCore.Identity;

namespace OneMoneyCloneServer.Models.Server;

public sealed class User : IdentityUser<Guid>
{
	public Guid MainCurrencyId { get; set; }
	public Currency MainCurrency { get; set; } = default!;
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

	public ICollection<Account> Accounts { get; set; } = [];
	public ICollection<Budget> Budgets { get; set; } = [];
	public ICollection<Category> Categories { get; set; } = [];
	public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
	public ICollection<SavingsBudget> SavingBudgets { get; set; } = [];
	public ICollection<TagBudget> TagBudgets { get; set; } = [];
}
