using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface ISavingsBudgetRepository
{
	Task<SavingsBudget?> GetSavingsBudgetByIdAsync(Guid id);
	Task<SavingsBudget?> CreateSavingsBudgetAsync(SavingsBudget savingsBudget);
	Task<SavingsBudget?> UpdateSavingsBudgetAsync(SavingsBudget savingsBudget);
	Task<SavingsBudget?> DeleteSavingsBudgetAsync(Guid id);
	Task<IEnumerable<SavingsBudget>> GetSavingsBudgetsByUserIdAsync(Guid userId);
	Task<IEnumerable<SavingsBudget>> GetSavingsBudgetsByUserIdAndPeriodAsync(Guid userId, DateOnly startDate, DateOnly endDate);
	Task<bool> IsSavingsBudgetForPeriodExists(Guid categoryId, DateOnly startDate, DateOnly endDate);
}