using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface ICategoryTagRepository
{
	Task<CategoryTag?> GetCategoryTagByIdAsync(Guid id);
	Task<CategoryTag?> CreateCategoryTagAsync(CategoryTag categoryTag);
	Task<CategoryTag?> UpdateCategoryTagAsync(CategoryTag categoryTag);
	Task<CategoryTag?> DeleteCategoryTagAsync(Guid id);
	Task<IEnumerable<CategoryTag>> GetCategoryTagsByUserIdAsync(Guid userId);
	Task<IEnumerable<CategoryTag>> GetCategoryTagsCategoryIdAsync(Guid categoryId);
}