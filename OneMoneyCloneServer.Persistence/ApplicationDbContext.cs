using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Persistence;

public sealed class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
	public DbSet<Account> Accounts { get; set; }
	public DbSet<Budget> Budgets { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<CategoryTag> CategoryTags { get; set; }
	public DbSet<Currency> Currencies { get; set; }
	public DbSet<RefreshToken> RefreshTokens { get; set; }
	public DbSet<SavingsBudget> SavingBudgets { get; set; }
	public DbSet<TagBudget> TagBudgets { get; set; }
	public DbSet<Transaction> Transactions { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
	}

	public Task EnsureDatabaseCreatedAsync()
	{
		return Database.MigrateAsync();
	}
}
