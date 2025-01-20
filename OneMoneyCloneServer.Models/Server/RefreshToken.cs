namespace OneMoneyCloneServer.Models;

public sealed class RefreshToken : CreationTrackingEntity
{
	public Guid Id { get; set; }
	public string Token { get; set; } = default!;
	public DateTime Expires { get; set; }
	public Guid UserId { get; set; } = default!;
	public User User { get; set; } = default!;
}
