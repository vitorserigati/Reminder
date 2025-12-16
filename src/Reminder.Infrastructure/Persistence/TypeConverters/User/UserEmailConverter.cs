using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Infrastructure.Persistence;

internal sealed class UserEmailConverter : ValueConverter<UserEmail, string>
{
    public UserEmailConverter() : base(userEmail => userEmail.Value, value => UserEmail.From(value))
    { }
}
