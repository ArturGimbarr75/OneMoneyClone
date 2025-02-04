using OneMoneyCloneServer.Application.Infrastructure;
using OneMoneyCloneServer.Application.Services.Auth.Errors;
using OneMoneyCloneServer.DTO.Auth;

namespace OneMoneyCloneServer.Application.Services.Auth;

public interface IUserService
{
	Task<AuthResponseDto> RegisterAsync(RegisterDto model);
	Task<InfoResult<AuthResponseDto, LoginErrors>> LoginAsync(LoginDto model);
	Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto model);
}
