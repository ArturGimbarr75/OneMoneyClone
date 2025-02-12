namespace OneMoneyCloneServer.DTO.Auth;

public class StringTokenPairDto
{
	public string Token { get; set; } = string.Empty;
	public string RefreshToken { get; set; } = string.Empty;
}