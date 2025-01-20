namespace OneMoneyCloneServer.Models.Server;

public abstract class CreationTrackingEntity
{
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
