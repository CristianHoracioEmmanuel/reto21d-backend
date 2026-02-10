namespace Reto21D.Domain.Entities;

public class Exercise
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public int? Reps { get; set; }
    public int? Sets { get; set; }
    public int? DurationSeconds { get; set; }

    public Guid WorkoutDayId { get; set; }
    public WorkoutDay WorkoutDay { get; set; } = default!;
}
