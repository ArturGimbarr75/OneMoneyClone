using OneMoneyCloneServer.DTO.Auth;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Application.Helpers;

internal static class RefreshTokenMapper
{
	internal static RefreshToken MapToModel(this AuthResponseDto authResponse)
	{
		return new RefreshToken
		{
			Token = authResponse.RefreshToken.Token,
			Expires = authResponse.RefreshToken.Expires,
			UserId = authResponse.User.Id
		};
	}
}
