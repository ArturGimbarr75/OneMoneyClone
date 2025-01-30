namespace OneMoneyCloneServer.DTO.Auth;

public class UserDto
{
	public Guid Id { get; set; }
	public string Email { get; set; } = string.Empty;
	public Guid MainCurrencyId { get; set; }
	public DateTime CreatedAt { get; set; }
}
