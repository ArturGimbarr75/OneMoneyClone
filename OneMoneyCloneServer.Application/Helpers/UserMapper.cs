using OneMoneyCloneServer.DTO.Auth;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Application.Helpers;

internal static class UserMapper
{
	internal static UserDto MapToDto(this User user)
	{
		return new UserDto
		{
			Id = user.Id,
			Email = user.Email!,
			CreatedAt = user.CreatedAt,
			MainCurrencyId = user.MainCurrencyId
		};
	}

	internal static User MapToModel(this UserDto userDto)
	{
		return new User
		{
			Id = userDto.Id,
			Email = userDto.Email,
			CreatedAt = userDto.CreatedAt,
			MainCurrencyId = userDto.MainCurrencyId
		};
	}

	internal static User MapToModel(this RegisterDto registerDto)
	{
		return new User
		{
			Email = registerDto.Email,
			UserName = registerDto.Email,
			MainCurrencyId = registerDto.MainCurrencyId
		};
	}
}
