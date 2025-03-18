using OneMoneyCloneServer.Application.Helpers;
using OneMoneyCloneServer.Application.Infrastructure;
using OneMoneyCloneServer.Application.Services.Account.Errors;
using OneMoneyCloneServer.DTO.Account;
using OneMoneyCloneServer.Repositories.Interfaces;

namespace OneMoneyCloneServer.Application.Services.Account;

public class AccountService : IAccountService
{
	private readonly IAccountRepository _accountRepository;
	private readonly ICurrencyRepository _currencyRepository;

	public AccountService(IAccountRepository accountRepository, ICurrencyRepository currencyRepository)
	{
		_accountRepository = accountRepository;
		_currencyRepository = currencyRepository;
	}

	public async Task<InfoResult<AccountDto?, CreateAccountErrors>> CreateAccountAsync(CreateAccountDto account, Guid userId)
	{
		if (account?.Name is null || account.CurrencyId == Guid.Empty)
			return InfoResult<AccountDto?, CreateAccountErrors>.WithInfo(CreateAccountErrors.InvalidAccountData, "Invalid account data");

		if (!await _currencyRepository.IsCurrencyExists(account.CurrencyId))
			return InfoResult<AccountDto?, CreateAccountErrors>.WithInfo(CreateAccountErrors.InvalidCurrency, "Invalid currency");

		var newAccount = account.MapToModel(userId);

		try
		{
			var createdAccount = await _accountRepository.CreateAccountAsync(newAccount);

			if (createdAccount is null)
				return InfoResult<AccountDto?, CreateAccountErrors>.WithInfo(CreateAccountErrors.InternalError, "Account was not created");

			return createdAccount.MapToDto();
		}
		catch (Exception ex)
		{
			return InfoResult<AccountDto?, CreateAccountErrors>.WithInfo(CreateAccountErrors.InternalError, ex.Message);
		}
	}

	public async Task<InfoResult<AccountDto?, AccountErrors>> DeleteAccountAsync(Guid id, Guid userId)
	{
		var account = await _accountRepository.GetAccountByIdAsync(id);

		if (account is null || account.UserId != userId)
			return InfoResult<AccountDto?, AccountErrors>.WithInfo(AccountErrors.AccountNotFound, "Account not found");

		try
		{
			var deletedAccount = await _accountRepository.DeleteAccountAsync(id);
			if (deletedAccount is null)
				return InfoResult<AccountDto?, AccountErrors>.WithInfo(AccountErrors.AccountNotFound, "Account not found");
			return deletedAccount.MapToDto();
		}
		catch (Exception ex)
		{
			return InfoResult<AccountDto?, AccountErrors>.WithInfo(AccountErrors.InternalError, ex.Message);
		}
	}

	public async Task<InfoResult<AccountDto?, AccountErrors>> GetAccountByIdAsync(Guid id, Guid userId)
	{
		var account = await _accountRepository.GetAccountByIdAsync(id);

		if (account is null || account.UserId != userId)
			return InfoResult<AccountDto?, AccountErrors>.WithInfo(AccountErrors.AccountNotFound, "Account not found");

		return account.MapToDto();
	}

	public async Task<InfoResult<IEnumerable<AccountDto>, AccountErrors>> GetAccountsByUserIdAsync(Guid userId)
	{
		var accounts = await _accountRepository.GetAccountsByUserIdAsync(userId);

		if (accounts is null)
			return InfoResult<IEnumerable<AccountDto>, AccountErrors>.WithInfo(AccountErrors.AccountNotFound, "Account not found");

		IEnumerable<AccountDto> accountDtos = accounts.Select(a => a.MapToDto());
		return InfoResult<IEnumerable<AccountDto>, AccountErrors>.Ok(accountDtos);
	}

	public async Task<InfoResult<AccountDto?, UpdateAccountErrors>> UpdateAccountAsync(AccountDto account, Guid userId)
	{
		if (account is null)
			return InfoResult<AccountDto?, UpdateAccountErrors>.WithInfo(UpdateAccountErrors.AccountNotFound, "Account not found");

		if (account.Name is null || !await _currencyRepository.IsCurrencyExists(account.CurrencyId))
			return InfoResult<AccountDto?, UpdateAccountErrors>.WithInfo(UpdateAccountErrors.InvalidAccountData, "Invalid account data");

		var existingAccount = await _accountRepository.GetAccountByIdAsync(account.Id);
		if (existingAccount is null || existingAccount.UserId != userId)
			return InfoResult<AccountDto?, UpdateAccountErrors>.WithInfo(UpdateAccountErrors.AccountNotFound, "Account not found");

		try
		{
			var model = account.MapToModel();
			await _accountRepository.UpdateAccountAsync(model);
			
			return model.MapToDto();
		}
		catch (Exception ex)
		{
			return InfoResult<AccountDto?, UpdateAccountErrors>.WithInfo(UpdateAccountErrors.InternalError, ex.Message);
		}
	}
}