using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface IBudgetRepository
{
	Task<Budget?> GetBudgetByIdAsync(Guid id);
	Task<Budget?> CreateBudgetAsync(Budget budget);
	Task<Budget?> UpdateBudgetAsync(Budget budget);
	Task<Budget?> DeleteBudgetAsync(Guid id);
	Task<IEnumerable<Budget>> GetBudgetsByUserIdAsync(Guid userId);
	Task<IEnumerable<Budget>> GetBudgetsByUserIdAndPeriodAsync(Guid userId, DateOnly startDate, DateOnly endDate);
	Task<bool> IsBudgetForPeriodExists(Guid userId, Guid expenceBudgetId, DateOnly startDate, DateOnly endDate);
}
