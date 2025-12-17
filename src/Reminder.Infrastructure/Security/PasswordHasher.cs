using System.Security.Cryptography;
using Reminder.Application.Interfaces;
using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Infrastructure.Security;

public sealed class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iteractions = 100_000;

    private readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    public PasswordHash Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iteractions, Algorithm, HashSize);

        string hashedPass = $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";

        return PasswordHash.From(hashedPass);
    }

    public bool Verify(string password, PasswordHash hash)
    {
        string[] parts = hash.Value!.Split('-');
        byte[] hashValue = Convert.FromHexString(parts[0]);
        byte[] salt = Convert.FromHexString(parts[1]);

        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iteractions, Algorithm, HashSize);

        return CryptographicOperations.FixedTimeEquals(hashValue, inputHash);
    }
}
