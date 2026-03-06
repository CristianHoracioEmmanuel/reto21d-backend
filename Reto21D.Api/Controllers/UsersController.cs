using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reto21D.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;


namespace Reto21D.Api.Controllers;

[ApiController]
[Route("users")]
[Authorize]

public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;

    public UsersController(AppDbContext db)
    {
        _db = db;
    }

    // GET /users
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _db.Users
            .Select(u => new
            {
                u.Id,
                u.Email,
                u.CreatedAt
            })
            .ToListAsync();

        return Ok(users);
    }
}
