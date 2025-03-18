using OneMoneyCloneServer.DTO.Account;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Application.Helpers;

internal static class AccountMapper
{
	internal static AccountDto MapToDto(this Account account)
	{
		return new AccountDto
		{
			Id = account.Id,
			Name = account.Name!,
			Balance = account.Balance,
			CurrencyId = account.CurrencyId,
			Type = account.Type
		};
	}

	internal static Account MapToModel(this AccountDto accountDto)
	{
		return new Account
		{
			Id = accountDto.Id,
			Name = accountDto.Name,
			Balance = accountDto.Balance,
			CurrencyId = accountDto.CurrencyId,
			Type = accountDto.Type
		};
	}

	internal static Account MapToModel(this CreateAccountDto createAccountDto, Guid userId)
	{
		return new Account
		{
			Name = createAccountDto.Name,
			Balance = createAccountDto.Balance,
			CurrencyId = createAccountDto.CurrencyId,
			Type = createAccountDto.Type,
			UserId = userId
		};
	}
}
