namespace OneMoneyCloneServer.DTO.Auth;

public class AuthResponseDto
{
	public string Token { get; set; } = string.Empty;
	public string RefreshToken { get; set; } = string.Empty;
	public UserDto User { get; set; } = default!;
}
