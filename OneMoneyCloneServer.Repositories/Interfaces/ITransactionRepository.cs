using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface ITransactionRepository
{
	Task<Transaction?> GetTransactionByIdAsync(Guid id);
	Task<Transaction?> CreateTransactionAsync(Transaction transaction);
	Task<Transaction?> UpdateTransactionAsync(Transaction transaction);
	Task<Transaction?> DeleteTransactionAsync(Guid id);
	Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(Guid userId);
	Task<IEnumerable<Transaction>> GetTransactionsByUserIdAndPeriodAsync(Guid userId, DateOnly startDate, DateOnly endDate);
	Task<IEnumerable<Transaction>> GetTransactionsByUserIdAndCategoryAsync(Guid userId, Guid categoryId);
	Task<IEnumerable<Transaction>> GetTransactionsByUserIdAndCategoryAndPeriodAsync(Guid userId, Guid categoryId, DateOnly startDate, DateOnly endDate);
}