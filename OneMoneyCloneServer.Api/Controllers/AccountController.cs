using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMoneyCloneServer.Application.Services.Account;
using OneMoneyCloneServer.DTO.Account;
using System.Security.Claims;

namespace OneMoneyCloneServer.Api.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController : ControllerBase
	{
		private readonly ILogger<AccountController> _logger;
		private readonly IAccountService _accountService;

		public AccountController(ILogger<AccountController> logger, IAccountService accountService)
		{
			_logger = logger;
			_accountService = accountService;
		}

		[HttpPost("create")]
		[ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<AccountDto>> CreateAccount([FromBody] CreateAccountDto account)
		{
			Guid userId = Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
			var result = await _accountService.CreateAccountAsync(account, userId);
			if (result)
				return Ok(result.Value);
			
			return BadRequest(string.Join(", ", result.Info));
		}

		[HttpPut("update")]
		[ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<AccountDto>> UpdateAccount([FromBody] AccountDto account)
		{
			Guid userId = Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
			var result = await _accountService.UpdateAccountAsync(account, userId);
			if (result)
				return Ok(result.Value);

			return BadRequest(string.Join(", ", result.Info));
		}

		[HttpDelete("delete/{id}")]
		[ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<AccountDto>> DeleteAccount(Guid id)
		{
			Guid userId = Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
			var result = await _accountService.DeleteAccountAsync(id, userId);
			if (result)
				return Ok(result.Value);
			
			return BadRequest(string.Join(", ", result.Info));
		}

		[HttpGet("get/{id}")]
		[ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<AccountDto>> GetAccountById(Guid id)
		{
			Guid userId = Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
			var result = await _accountService.GetAccountByIdAsync(id, userId);
			if (result)
				return Ok(result.Value);

			return BadRequest(string.Join(", ", result.Info));
		}
		
		[HttpGet("get")]
		[ProducesResponseType(typeof(IEnumerable<AccountDto>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccountsByUserId()
		{
			Guid userId = Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
			var result = await _accountService.GetAccountsByUserIdAsync(userId);
			if (result)
				return Ok(result.Value);

			return BadRequest(string.Join(", ", result.Info));
		}
	}
}