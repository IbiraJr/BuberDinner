using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Services;
using BuberDinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimerProvider dateTimerProvider;
    private readonly JwtSettings jwtSettings;
    public JwtTokenGenerator(IDateTimerProvider dateTimerProvider, IOptions<JwtSettings> jwtOptions)
    {
        this.dateTimerProvider = dateTimerProvider;
        this.jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
           new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
           new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
           new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),
           new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
       };
        var securityToken = new JwtSecurityToken(
            issuer: this.jwtSettings.Issuer,
            audience: this.jwtSettings.Audience,
            expires: this.dateTimerProvider.UtcNow.AddMinutes(this.jwtSettings.ExpiryInMinutes),
            claims: claims,
            signingCredentials: signingCredentials
            ); ;;
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
