using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Persistence.EntityConfigurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users");
		builder.HasKey(u => u.Id);

		builder.HasOne(u => u.MainCurrency)
			.WithMany(c => c.Users)
			.HasForeignKey(u => u.MainCurrencyId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(u => u.CreatedAt).IsRequired();
		builder.Property(u => u.UpdatedAt).IsRequired();
	}
}
