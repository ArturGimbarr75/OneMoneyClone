namespace OneMoneyCloneServer.Models.Server;

public abstract class BudgetBase : CreationTrackingEntity
{
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public User User { get; set; } = default!;
	public decimal Amount { get; set; }
	public DateOnly StartDate { get; set; }
	public DateOnly EndDate { get; set; }
}
