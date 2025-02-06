using OneMoneyCloneServer.Application.Infrastructure;
using OneMoneyCloneServer.Application.Services.Auth.Errors;
using OneMoneyCloneServer.DTO.Auth;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Application.Services.Auth;

public interface IUserService
{
	Task<InfoResult<AuthResponseDto, RegisterErrors>> RegisterAsync(RegisterDto model);
	Task<InfoResult<AuthResponseDto, LoginErrors>> LoginAsync(LoginDto model);
	Task<InfoResult<AuthResponseDto, RefreshTokenErrors>> RefreshTokenAsync(StringTokenPairDto tokenPair);
}
