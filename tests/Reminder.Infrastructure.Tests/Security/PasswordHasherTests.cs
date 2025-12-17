using Reminder.Infrastructure.Security;

public class PasswordHasherTests
{
    private readonly PasswordHasher _hasher;
    private readonly ITestOutputHelper _output;

    private const string Password = "somepasswordwithlotsofcharacters";

    public PasswordHasherTests(ITestOutputHelper output)
    {
        _output = output;
        _hasher = new PasswordHasher();
    }

    [Fact(DisplayName = "Hash must return a correct hash format. (hash-salt).")]
    public void Hash_ShouldReturnValidHashFormat()
    {

        string hash = _hasher.Hash(Password).Value;
        _output.WriteLine($"Hash Generated: {hash}.");

        hash.Should().Contain("-", "Because the format is: hash-salt.");

        string[] parts = hash.Split("-");

        parts.Length.Should().Be(2, "Because the format is composed by two parts.");

        parts[0].Should().NotBeNullOrWhiteSpace("Must contain the hashed password.");
        parts[1].Should().NotBeNullOrWhiteSpace("Must contain the salt.");
    }

    [Fact(DisplayName = "Hash must be undeterministic (each call generates a different result).")]
    public void Hash_ShouldProduceDifferentHashes_ForSamePassword()
    {
        string hash1 = _hasher.Hash(Password).Value;
        string hash2 = _hasher.Hash(Password).Value;

        hash1.Should().NotBe(hash2, "Random salts must generate different hashes.");
    }

    [Fact(DisplayName = "Must return true for a correct password.")]
    public void Verify_ShouldReturnTrue_ForCorrectPassword()
    {
        var generatedHash = _hasher.Hash(Password);

        bool result = _hasher.Verify(Password, generatedHash);

        result.Should().BeTrue("Password must correspond to generated hash.");
    }

    [Fact(DisplayName = "Must return false for a incorrect password")]
    public void Verify_ShouldReturnFalse_ForIncorrectPassword()
    {
        var generatedHash = _hasher.Hash(Password);

        string otherPassword = "anotherPassword";

        bool result = _hasher.Verify(otherPassword, generatedHash);

        result.Should().BeFalse("Must return false if incorrect password is given");
    }
}
