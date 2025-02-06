namespace OneMoneyCloneServer.Application.Services.Auth.Errors;

public enum RefreshTokenErrors
{
	ExpiredToken,
	InvalidRefreshToken,
	InvalidToken,
	InternalError,
	RefreshTokenRevoked,
	RefreshTokenUsed,
	UserNotFound
}