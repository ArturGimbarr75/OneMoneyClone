using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;
using OneMoneyCloneServer.Persistence;
using OneMoneyCloneServer.Repositories.Interfaces;

namespace OneMoneyCloneServer.Repositories.EF;
internal class RefreshTokenRepository : IRefreshTokenRepository
{
	private readonly ApplicationDbContext _context;

	public RefreshTokenRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<RefreshToken?> CreateRefreshTokenAsync(RefreshToken refreshToken)
	{
		var token = await _context.RefreshTokens.AddAsync(refreshToken);

		if (await _context.SaveChangesAsync() > 0)
			return token.Entity;

		return null;
	}

	public async Task<RefreshToken?> DeleteRefreshTokenAsync(string token)
	{
		var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token);

		if (refreshToken == null)
			return null;

		_context.RefreshTokens.Remove(refreshToken);
		if (await _context.SaveChangesAsync() > 0)
			return refreshToken;

		return null;
	}

	public Task<RefreshToken?> GetRefreshTokenByTokenAsync(string token)
	{
		return _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token);
	}

	public async Task<RefreshToken?> UpdateRefreshTokenAsync(RefreshToken refreshToken)
	{
		var entity = _context.RefreshTokens.Update(refreshToken);

		if (entity is null)
			return null;

		if (await _context.SaveChangesAsync() > 0)
			return entity.Entity;

		return null;
	}
}
