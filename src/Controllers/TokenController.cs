using ShopStore.Models;
using ShopStore.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenController: ControllerBase
{
    public IConfiguration _configuration;
    private readonly DataContext _context;
    public TokenController(IConfiguration configuration, DataContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost]
    [Route("api/token")]
    public async Task<IActionResult> Post([FromBody] UserInfo userInfo)
    {
        //var user = await _context.UserInfos.FirstOrDefaultAsync(u => u.UserName == userInfo.UserName && u.Password == userInfo.Password);
        //if (user != null)
        if(userInfo.UserName == "admin" && userInfo.Password == "P@ssw0rd")
        {
            var tokenString = GenerateToken(userInfo);
            return Ok(tokenString);
        }
        return Unauthorized();
    }

    private Task GenerateToken(UserInfo user)
    {
        // create claims details based on the user information
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        // generate signing key
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        // create token
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds
        );
        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
}