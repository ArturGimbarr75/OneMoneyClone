namespace OneMoneyCloneServer.DTO.Auth;

public class AuthResponseDto
{
	public string AccessToken { get; set; } = string.Empty;
	public RefreshTokenDto RefreshToken { get; set; } = default!;
	public UserDto User { get; set; } = default!;
}
