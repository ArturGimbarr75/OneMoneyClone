using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Persistence.EntityConfigurations;

internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
	public void Configure(EntityTypeBuilder<Transaction> builder)
	{
		builder.ToTable("Transactions");
		builder.HasKey(t => t.Id);

		builder.HasOne(t => t.Currency)
			.WithMany(c => c.Transactions)
			.HasForeignKey(t => t.CurrencyId);

		builder.HasOne(t => t.Account)
			.WithMany(a => a.Transactions)
			.HasForeignKey(t => t.AccountId);

		builder.HasOne(t => t.Category)
			.WithMany(c => c.Transactions)
			.HasForeignKey(t => t.CategoryId);

		builder.Property(t => t.Amount).IsRequired();
		builder.Property(t => t.Date).IsRequired();
	}
}
