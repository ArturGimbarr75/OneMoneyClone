using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Persistence.EntityConfigurations;

internal class TagBudgetConfiguration : IEntityTypeConfiguration<TagBudget>
{
	public void Configure(EntityTypeBuilder<TagBudget> builder)
	{
		builder.ToTable("TagBudgets");
		builder.HasKey(tb => tb.Id);

		builder.HasOne(tb => tb.User)
			.WithMany(u => u.TagBudgets)
			.HasForeignKey(tb => tb.UserId);

		builder.HasOne(tb => tb.CategoryTag)
			.WithMany(ct => ct.TagBudgets)
			.HasForeignKey(tb => tb.CategoryTagId);

		builder.Property(tb => tb.Amount).IsRequired();

		builder.Property(tb => tb.StartDate)
			.HasConversion(v => v.ToDateTime(TimeOnly.MinValue), v => DateOnly.FromDateTime(v))
			.IsRequired();

		builder.Property(tb => tb.EndDate)
			.HasConversion(v => v.ToDateTime(TimeOnly.MinValue), v => DateOnly.FromDateTime(v))
			.IsRequired();
	}
}
