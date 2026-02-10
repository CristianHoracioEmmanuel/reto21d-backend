namespace Reto21D.Domain.Entities;

public class UserProgress
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid WorkoutDayId { get; set; }
    public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
}
