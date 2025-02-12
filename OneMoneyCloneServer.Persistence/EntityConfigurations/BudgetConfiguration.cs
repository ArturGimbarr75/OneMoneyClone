using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Persistence.EntityConfigurations;

internal class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
	public void Configure(EntityTypeBuilder<Budget> builder)
	{
		builder.ToTable("Budgets");
		builder.HasKey(b => b.Id);

		builder.HasOne(b => b.User)
			.WithMany(u => u.Budgets)
			.HasForeignKey(b => b.UserId);

		builder.HasOne(b => b.Category)
			.WithMany(c => c.SavingsBudgets)
			.HasForeignKey(b => b.CategoryId);

		builder.Property(b => b.Amount).IsRequired();

		builder.Property(b => b.StartDate)
			.HasConversion(v => v.ToDateTime(TimeOnly.MinValue), v => DateOnly.FromDateTime(v))
			.IsRequired();

		builder.Property(b => b.EndDate)
			.HasConversion(v => v.ToDateTime(TimeOnly.MinValue), v => DateOnly.FromDateTime(v))
			.IsRequired();
	}
}
