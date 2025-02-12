namespace OneMoneyCloneServer.DTO.Auth;

public class RefreshTokenDto
{
	public string Token { get; set; } = string.Empty;
	public DateTime Expires { get; set; }
}
