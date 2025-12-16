using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Infrastructure.Persistence;

internal sealed class UserNameConverter : ValueConverter<UserName, string>
{
    public UserNameConverter() : base(userName => userName.Value, value => UserName.From(value))
    { }
}
