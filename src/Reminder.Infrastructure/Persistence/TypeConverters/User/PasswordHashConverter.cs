using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Infrastructure.Persistence;

internal sealed class PasswordHashConverter : ValueConverter<PasswordHash, string>
{
    public PasswordHashConverter() : base(passwordHash => passwordHash.Value, value => PasswordHash.From(value))
    { }
}
