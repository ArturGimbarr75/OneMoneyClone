using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface ICurrencyRepository
{
	Task<bool> IsCurrencyExists(Guid id);
	Task<Currency?> GetCurrencyByIdAsync(Guid id);
	Task<IEnumerable<Currency>> GetCurrenciesAsync();
}