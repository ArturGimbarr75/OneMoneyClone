using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;
using OneMoneyCloneServer.Persistence;
using OneMoneyCloneServer.Repositories.Interfaces;

namespace OneMoneyCloneServer.Repositories.EF;

internal class AccountRepository : IAccountRepository
{
	private readonly ApplicationDbContext _context;

	public AccountRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Account?> CreateAccountAsync(Account account)
	{
		var acc = await _context.Accounts.AddAsync(account);

		if (_context.SaveChanges() > 0)
			return acc.Entity;

		return null;
	}

	public async Task<Account?> DeleteAccountAsync(Guid id)
	{
		var account = _context.Accounts.Find(id);

		_context.Accounts.Remove(account);
		if (await _context.SaveChangesAsync() > 0)
			return account;

		return null;
	}

	public Task<Account?> GetAccountByIdAsync(Guid id)
	{
		return _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
	}

	public async Task<IEnumerable<Account>> GetAccountsByUserIdAsync(Guid userId)
	{
		return await _context.Accounts.Where(a => a.UserId == userId).ToListAsync();
	}

	public async Task<IEnumerable<Account>> GetAccountsOfTypeByUserIdAsync(Guid userId, AccountType type)
	{
		return await _context.Accounts.Where(a => a.UserId == userId && a.Type == type).ToListAsync();
	}

	public async Task<Account?> UpdateAccountAsync(Account account)
	{
		var acc = _context.Accounts.Update(account);
		
		if (await _context.SaveChangesAsync() > 0)
			return acc.Entity;

		return null;
	}
}
