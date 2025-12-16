using System.Text.RegularExpressions;
using ValueOf;

namespace Reminder.Domain.ValueObjects.Users;

public sealed class UserEmail : ValueOf<string, UserEmail>
{
    private readonly string _expression = @"^(?!\.)(?!.*\.\.)[A-Za-z0-9._%+-]+(?<!\.)@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException("Email is required");

        if (!Regex.IsMatch(Value, _expression, RegexOptions.IgnoreCase))
            throw new ArgumentException("Invalid Email");
    }
}


