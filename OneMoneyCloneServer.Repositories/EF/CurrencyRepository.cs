using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;
using OneMoneyCloneServer.Persistence;
using OneMoneyCloneServer.Repositories.Interfaces;

namespace OneMoneyCloneServer.Repositories.EF;

internal class CurrencyRepository : ICurrencyRepository
{
	private readonly ApplicationDbContext _context;

	public CurrencyRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Currency>> GetCurrenciesAsync()
	{
		return await _context.Currencies.ToListAsync();
	}

	public Task<Currency?> GetCurrencyByIdAsync(Guid id)
	{
		return _context.Currencies.FirstOrDefaultAsync(c => c.Id == id);
	}

	public Task<bool> IsCurrencyExists(Guid id)
	{
		return _context.Currencies.AnyAsync(c => c.Id == id);
	}
}
