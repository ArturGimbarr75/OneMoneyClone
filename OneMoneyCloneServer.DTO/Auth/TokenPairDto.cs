namespace OneMoneyCloneServer.DTO.Auth;

public class TokenPairDto
{
	public string Token { get; set; } = string.Empty;
	public RefreshTokenDto RefreshToken { get; set; } = default!;
}