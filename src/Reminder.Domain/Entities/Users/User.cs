using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Domain.Entities;

public sealed record User(UserId Id, UserName FullName, UserEmail Email, PasswordHash PasswordHash, UserCreatedAt CreatedAt);
