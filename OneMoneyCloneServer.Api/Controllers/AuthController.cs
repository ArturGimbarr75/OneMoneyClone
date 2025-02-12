using Microsoft.AspNetCore.Mvc;
using OneMoneyCloneServer.Application.Services.Auth;
using OneMoneyCloneServer.Application.Services.Auth.Errors;
using OneMoneyCloneServer.DTO.Auth;
using System.Text;

namespace OneMoneyCloneServer.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly ILogger<AuthController> _logger;
		private readonly IUserService _userService;

		public AuthController(ILogger<AuthController> logger, IUserService userService)
		{
			_logger = logger;
			_userService = userService;
		}

		[HttpPost("register")]
		[ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registrationData)
		{
			var result = await _userService.RegisterAsync(registrationData);

			if (result)
				return Ok(result.Value);

			return BadRequest(string.Join(", ", result.Info));
		}

		[HttpPost("login")]
		[ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto loginData)
		{
			var result = await _userService.LoginAsync(loginData);

			if (result)
				return Ok(result.Value);

			return BadRequest(string.Join(", ", result.Info));
		}

		[HttpPost("refresh")]
		[ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<AuthResponseDto>> Refresh([FromBody] StringTokenPairDto tokenPair)
		{
			var result = await _userService.RefreshTokenAsync(tokenPair);

			if (result)
				return Ok(result.Value);

			return BadRequest(string.Join(", ", result.Info));
		}

		[HttpPost("logout")]
		[ProducesResponseType(StatusCodes.Status501NotImplemented)]
		public async Task<ActionResult> Logout([FromBody] StringTokenPairDto tokenPair)
		{
			var result = await _userService.LogoutAsync(tokenPair);

			if (result)
				return Ok();

			return BadRequest(string.Join(", ", result.Info));
		}
	}
}
