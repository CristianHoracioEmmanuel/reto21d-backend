using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reto21D.Infrastructure.Persistence;

namespace Reto21D.Api.Controllers;

[ApiController]
[Route("challenge")]
public class ChallengeController : ControllerBase
{
    private readonly AppDbContext _db;

    public ChallengeController(AppDbContext db)
    {
        _db = db;
    }

    // GET /challenge/active
   [HttpGet("active")]
public async Task<IActionResult> GetActive()
{
    var challenge = await _db.Challenges
        .AsNoTracking()
        .OrderByDescending(c => c.Id)
        .Select(c => new
        {
            c.Id,
            c.Name,
            c.Description
        })
        .FirstOrDefaultAsync();

    if (challenge is null)
        return NotFound(new { message = "No hay challenge cargado." });

    return Ok(challenge);
}


    // GET /challenge/day/1
    [HttpGet("day/{dayNumber:int}")]
    public async Task<IActionResult> GetDay(int dayNumber)
    {
        var day = await _db.WorkoutDays
            .AsNoTracking()
            .Where(d => d.DayNumber == dayNumber)
            .Select(d => new
            {
                d.Id,
                d.DayNumber,
                d.Title,
                d.Description,
                exercises = d.Exercises.Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Sets,
                    e.Reps,
                    e.DurationSeconds
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (day is null)
            return NotFound(new { message = $"No existe el día {dayNumber}." });

        return Ok(day);
    }
}
