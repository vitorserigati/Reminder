using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Reminder.Application.Interfaces;
using Reminder.Application.Types;
using Reminder.Domain.Entities;

namespace Reminder.Infrastructure.Security;

public sealed class TokenProvider : ITokenProvider
{
    private readonly IConfiguration _config;
    private readonly JwtSettings _settings;

    public TokenProvider(IConfiguration config, IOptions<JwtSettings> settings) =>
        (_config, _settings) = (config, settings.Value);

    public string Create(User user)
    {
        byte[] key = Encoding.UTF8.GetBytes(_settings.Secret);
        DateTime tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(_settings.ExpirationInMinutes);
        SigningCredentials signingCred = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);

        Claim[] claims = [
            new Claim(JwtRegisteredClaimNames.Name, user.FullName.Value),
            new Claim(JwtRegisteredClaimNames.Email, user.Email.Value),
        ];

        var token = new JwtSecurityToken(_settings.Issuer, _settings.Audience, claims, expires: tokenExpiryTimeStamp, signingCredentials: signingCred);
        JwtSecurityTokenHandler handler = new();

        return handler.WriteToken(token);
    }
}
