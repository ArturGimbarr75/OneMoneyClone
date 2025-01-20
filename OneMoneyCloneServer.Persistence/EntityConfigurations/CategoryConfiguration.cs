using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Persistence.EntityConfigurations;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.ToTable("Categories");
		builder.HasKey(c => c.Id);

		builder.HasOne(c => c.User)
			.WithMany(u => u.Categories)
			.HasForeignKey(c => c.UserId);

		builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
	}
}
