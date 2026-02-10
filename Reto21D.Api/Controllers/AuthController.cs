using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reto21D.Api.Dtos;
using Reto21D.Api.Services;
using Reto21D.Domain.Entities;
using Reto21D.Infrastructure.Persistence;


namespace Reto21D.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly TokenService _tokenService;

    public AuthController(AppDbContext db, TokenService tokenService)
    {
        _db = db;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register(RegisterRequest req)
    {
        var email = req.Email.Trim().ToLowerInvariant();

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(req.Password))
            return BadRequest("Email y password obligatorios");

        if (await _db.Users.AnyAsync(u => u.Email == email))
            return Conflict("Email ya registrado");

        var user = new User
        {
            Email = email,
            PasswordHash = PasswordHasher.Hash(req.Password)
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        var token = _tokenService.CreateToken(user.Id, user.Email);
        return Ok(new AuthResponse(token, user.Email));
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginRequest req)
    {
        var email = req.Email.Trim().ToLowerInvariant();

        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) return Unauthorized();

        if (!PasswordHasher.Verify(req.Password, user.PasswordHash))
            return Unauthorized();

        var token = _tokenService.CreateToken(user.Id, user.Email);
        return Ok(new AuthResponse(token, user.Email));
    }
}
