using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface ICategoryRepository
{
	Task<Category?> GetCategoryByIdAsync(Guid id);
	Task<Category?> CreateCategoryAsync(Category category);
	Task<Category?> UpdateCategoryAsync(Category category);
	Task<Category?> DeleteCategoryAsync(Guid id);
	Task<IEnumerable<Category>> GetCategoriesByUserIdAsync(Guid userId);
	Task<IEnumerable<Category>> GetCategoriesByUserIdAndTypeAsync(Guid userId, CategoryType type);
}