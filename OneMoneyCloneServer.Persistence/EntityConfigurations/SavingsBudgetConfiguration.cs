using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Persistence.EntityConfigurations;

internal class SavingsBudgetConfiguration : IEntityTypeConfiguration<SavingsBudget>
{
	public void Configure(EntityTypeBuilder<SavingsBudget> builder)
	{
		builder.ToTable("SavingsBudgets");
		builder.HasKey(sb => sb.Id);

		builder.HasOne(sb => sb.User)
			.WithMany(u => u.SavingBudgets)
			.HasForeignKey(sb => sb.UserId);

		builder.HasOne(sb => sb.Account)
			.WithMany(a => a.SavingsBudgets)
			.HasForeignKey(sb => sb.AccountId);

		builder.Property(sb => sb.Amount).IsRequired();

		builder.Property(sb => sb.StartDate)
			.HasConversion(v => v.ToDateTime(TimeOnly.MinValue), v => DateOnly.FromDateTime(v))
			.IsRequired();

		builder.Property(sb => sb.EndDate)
			.HasConversion(v => v.ToDateTime(TimeOnly.MinValue), v => DateOnly.FromDateTime(v))
			.IsRequired();

		builder.Property(sb => sb.AmountInMainCurrency).IsRequired();
	}
}
