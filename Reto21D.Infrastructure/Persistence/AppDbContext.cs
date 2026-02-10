using Microsoft.EntityFrameworkCore;
using Reto21D.Domain.Entities;

namespace Reto21D.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Challenge> Challenges => Set<Challenge>();
    public DbSet<WorkoutDay> WorkoutDays => Set<WorkoutDay>();
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<UserProgress> UserProgress => Set<UserProgress>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique();

        modelBuilder.Entity<Challenge>()
            .HasMany(c => c.Days)
            .WithOne(d => d.Challenge)
            .HasForeignKey(d => d.ChallengeId);

        modelBuilder.Entity<WorkoutDay>()
            .HasMany(d => d.Exercises)
            .WithOne(e => e.WorkoutDay)
            .HasForeignKey(e => e.WorkoutDayId);
    }
}
