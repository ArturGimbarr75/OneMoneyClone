using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Persistence.EntityConfigurations;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
	public void Configure(EntityTypeBuilder<Account> builder)
	{
		builder.ToTable("Accounts");
		builder.HasKey(a => a.Id);

		builder.HasOne(a => a.Currency)
			.WithMany(c => c.Accounts)
			.HasForeignKey(a => a.CurrencyId);

		builder.HasOne(a => a.User)
			.WithMany(u => u.Accounts)
			.HasForeignKey(a => a.UserId);

		builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
		builder.Property(a => a.Balance).IsRequired();
		builder.Property(a => a.Type).IsRequired();
	}
}
