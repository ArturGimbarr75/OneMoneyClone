﻿using OneMoneyCloneServer.DTO.Auth;

namespace OneMoneyCloneClient.Application.Services.Api.Interfaces;

public interface IAuthService
{
	Task<bool> LoginAsync(LoginDto model);
	Task<bool> RegisterAsync(RegisterDto model);
	Task<bool> RefreshTokenAsync();
	Task<bool> LogoutAsync();
	Task<bool> LogoutFromAllDevicesAsync();
}
