using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Persistence.EntityConfigurations;

internal class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
	public void Configure(EntityTypeBuilder<RefreshToken> builder)
	{
		builder.ToTable("RefreshTokens");
		builder.HasKey(rt => rt.Id);

		builder.HasOne(rt => rt.User)
			.WithMany(u => u.RefreshTokens)
			.HasForeignKey(rt => rt.UserId)
			.IsRequired()
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(rt => rt.Token).IsRequired();
		builder.Property(rt => rt.Expires).IsRequired();
		builder.Property(rt => rt.IsUsed).IsRequired();
		builder.Property(rt => rt.IsRevoked).IsRequired();
	}
}
