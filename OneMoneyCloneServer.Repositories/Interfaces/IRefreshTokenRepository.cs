using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface IRefreshTokenRepository
{
	Task<RefreshToken?> GetRefreshTokenByTokenAsync(string token);
	Task<RefreshToken?> CreateRefreshTokenAsync(RefreshToken refreshToken);
	Task<RefreshToken?> UpdateRefreshTokenAsync(RefreshToken refreshToken);
	Task<RefreshToken?> DeleteRefreshTokenAsync(string token);
}