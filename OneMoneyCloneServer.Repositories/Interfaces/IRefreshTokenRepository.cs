using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface IRefreshTokenRepository
{
	Task<RefreshToken?> GetRefreshTokenByTokenAsync(string token);
	Task<IEnumerable<RefreshToken>> GetValidRefreshTokensByUserIdAsync(Guid userId);
	Task<RefreshToken?> CreateRefreshTokenAsync(RefreshToken refreshToken);
	Task<RefreshToken?> UpdateRefreshTokenAsync(RefreshToken refreshToken);
	Task<IEnumerable<RefreshToken>> UpdateRefreshTokensAsync(IEnumerable<RefreshToken> refreshTokens);
	Task<RefreshToken?> DeleteRefreshTokenAsync(string token);
}