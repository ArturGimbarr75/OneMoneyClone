using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface IAccountsRepository
{
	Task<Account?> GetAccountByIdAsync(Guid id);
	Task<Account?> CreateAccountAsync(Account account);
	Task<Account?> UpdateAccountAsync(Account account);
	Task<Account?> DeleteAccountAsync(Guid id);
	Task<IEnumerable<Account>> GetAccountsByUserIdAsync(Guid userId);
	Task<IEnumerable<Account>> GetAccountsOfTypeByUserIdAsync(Guid userId, AccountType type);
}
