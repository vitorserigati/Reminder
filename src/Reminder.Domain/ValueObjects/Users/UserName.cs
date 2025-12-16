using ValueOf;

namespace Reminder.Domain.ValueObjects.Users;

public sealed class UserName : ValueOf<string, UserName>
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException("Name must be present");

        if (Value.Length < 5)
            throw new ArgumentException("Full Name is Required");
    }
}
