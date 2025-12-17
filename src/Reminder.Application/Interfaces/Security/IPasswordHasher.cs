using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Application.Interfaces;

public interface IPasswordHasher
{
    PasswordHash Hash(string password);
    bool Verify(string password, PasswordHash hash);
}
