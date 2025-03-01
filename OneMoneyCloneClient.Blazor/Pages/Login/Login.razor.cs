using Microsoft.AspNetCore.Components;
using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using OneMoneyCloneServer.DTO.Auth;

namespace OneMoneyCloneClient.Blazor.Pages.Login;

public partial class Login
{
	private IAuthService _authService { get; set; }

	private bool _isLogin = true;
	private LoginDto _loginDto = new();
	private RegisterDto _registerDto = new();
	private string _repeatPassword = string.Empty;

	public Login(IAuthService authService)
	{
		_authService = authService;
	}

	private async Task HandleLogin()
	{
		bool success = await _authService.LoginAsync(_loginDto);
	}

	private async Task HandleRegister()
	{
		bool success = await _authService.RegisterAsync(_registerDto);
	}

	private void SwitchToLogin()
	{
		_isLogin = true;
		_loginDto.Email = _registerDto.Email;
		_loginDto.Password = string.Empty;
	}

	private void SwitchToRegister()
	{
		_isLogin = false;
		_registerDto.Email = _loginDto.Email;
		_registerDto.Password = string.Empty;
		_repeatPassword = string.Empty;
	}
}