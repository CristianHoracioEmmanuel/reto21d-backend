namespace Reto21D.Domain.Entities;

public class Challenge
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int DurationDays { get; set; } = 21;

    public List<WorkoutDay> Days { get; set; } = new();
}
