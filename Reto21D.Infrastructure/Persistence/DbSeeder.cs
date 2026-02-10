using Reto21D.Domain.Entities;

namespace Reto21D.Infrastructure.Persistence;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        // Si ya hay data, no hacemos nada
        if (db.Challenges.Any() || db.WorkoutDays.Any())
            return;

        // 1) Crear y guardar Challenge primero
        var challenge = new Challenge
        {
            Name = "Reto21D",
            Description = "Reto de 21 días: hábitos + entrenamiento.",
            DurationDays = 21
        };

        db.Challenges.Add(challenge);
        db.SaveChanges(); // 👈 IMPORTANTE para que tenga Id real

        // 2) Crear día 1 asociado al challenge
        var day1 = new WorkoutDay
        {
            ChallengeId = challenge.Id,   // 👈 clave
            DayNumber = 1,
            Title = "Día 1 - Base",
            Description = "Calentamiento + circuito full body"
        };

        db.WorkoutDays.Add(day1);
        db.SaveChanges(); // 👈 para que day1 tenga Id

        // 3) Crear ejercicios asociados al día
        db.Exercises.AddRange(
            new Exercise { WorkoutDayId = day1.Id, Name = "Push ups", Sets = 3, Reps = 10, DurationSeconds = 0 },
            new Exercise { WorkoutDayId = day1.Id, Name = "Air Squats", Sets = 3, Reps = 15, DurationSeconds = 0 },
            new Exercise { WorkoutDayId = day1.Id, Name = "Plank", Sets = 3, Reps = 0, DurationSeconds = 30 }
        );

        db.SaveChanges();
    }
}
