namespace Reto21D.Domain.Entities;

public class WorkoutDay
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int DayNumber { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;

    public Guid ChallengeId { get; set; }
    public Challenge Challenge { get; set; } = default!;

    public List<Exercise> Exercises { get; set; } = new();
}
