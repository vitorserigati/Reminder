using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Infrastructure.Persistence;

internal sealed class UserIdConverter : ValueConverter<UserId, Guid>
{
    public UserIdConverter() : base(id => id.Value, value => UserId.From(value))
    { }
}
