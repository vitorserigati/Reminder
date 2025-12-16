using ValueOf;

namespace Reminder.Domain.ValueObjects.Users;

public sealed class UserCreatedAt : ValueOf<DateTime, UserCreatedAt>
{
    protected override void Validate()
    {
        if (Value > DateTime.UtcNow)
            throw new ArgumentException("User cannot be created on the future");
    }
}
