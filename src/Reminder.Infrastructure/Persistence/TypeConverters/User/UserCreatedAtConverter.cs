using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Infrastructure.Persistence;

internal sealed class UserCreatedAtConverter : ValueConverter<UserCreatedAt, DateTime>
{
    public UserCreatedAtConverter() : base(userCreatedAt => userCreatedAt.Value, value => UserCreatedAt.From(value))
    { }
}
