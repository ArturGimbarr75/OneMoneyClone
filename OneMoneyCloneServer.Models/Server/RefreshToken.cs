namespace OneMoneyCloneServer.Models.Server;

public sealed class RefreshToken : CreationTrackingEntity
{
	public Guid Id { get; set; }
	public string Token { get; set; } = default!;
	public DateTime Expires { get; set; }
	public bool IsUsed { get; set; }
	public bool IsRevoked { get; set; }
	public Guid UserId { get; set; }

	public User User { get; set; } = default!;
}
