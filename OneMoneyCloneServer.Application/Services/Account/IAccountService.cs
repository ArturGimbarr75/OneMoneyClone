using OneMoneyCloneServer.Application.Infrastructure;
using OneMoneyCloneServer.Application.Services.Account.Errors;
using OneMoneyCloneServer.DTO.Account;

namespace OneMoneyCloneServer.Application.Services.Account;

public interface IAccountService
{
	Task<InfoResult<AccountDto?, CreateAccountErrors>> CreateAccountAsync(CreateAccountDto account, Guid userId);
	Task<InfoResult<AccountDto?, UpdateAccountErrors>> UpdateAccountAsync(AccountDto account, Guid userId);
	Task<InfoResult<AccountDto?, AccountErrors>> DeleteAccountAsync(Guid id, Guid userId);
	Task<InfoResult<AccountDto?, AccountErrors>> GetAccountByIdAsync(Guid id, Guid userId);
	Task<InfoResult<IEnumerable<AccountDto>, AccountErrors>> GetAccountsByUserIdAsync(Guid userId);
}
