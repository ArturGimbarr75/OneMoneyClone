using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Persistence.EntityConfigurations;

internal class CategoryTagConfiguration : IEntityTypeConfiguration<CategoryTag>
{
	public void Configure(EntityTypeBuilder<CategoryTag> builder)
	{
		builder.ToTable("CategoryTags");
		builder.HasKey(ct => ct.Id);

		builder.HasOne(ct => ct.Category)
			.WithMany(c => c.CategoryTags)
			.HasForeignKey(ct => ct.CategoryId);

		builder.Property(ct => ct.Name).IsRequired().HasMaxLength(50);
	}
}
