using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface ITagBudget
{
	Task<TagBudget?> GetBudgetByIdAsync(Guid id);
	Task<TagBudget?> CreateBudgetAsync(TagBudget budget);
	Task<TagBudget?> UpdateBudgetAsync(TagBudget budget);
	Task<TagBudget?> DeleteBudgetAsync(Guid id);
	Task<IEnumerable<TagBudget>> GetBudgetsByUserIdAsync(Guid userId);
	Task<IEnumerable<TagBudget>> GetBudgetsByUserIdAndPeriodAsync(Guid userId, DateOnly startDate, DateOnly endDate);
	Task<bool> IsBudgetForPeriodExists(Guid categoryId, DateOnly startDate, DateOnly endDate);
}