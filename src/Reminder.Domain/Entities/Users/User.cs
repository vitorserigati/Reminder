using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Domain.Entities;

public sealed record User(UserId Id, UserName FullName, UserEmail Email, PasswordHash PasswordHash, UserCreatedAt CreatedAt);

public static class UserExtensions
{
    extension(User)
    {
        public static User CreateNew(string fullName, string email, string passwordHash, DateTime createdAt) =>
            CreateValid(Guid.CreateVersion7(), fullName, email, passwordHash, createdAt);

        public static User Restore(Guid id, string fullName, string email, string passwordHash, DateTime createdAt) =>
            CreateValid(id, fullName, email, passwordHash, createdAt);

        private static User CreateValid(Guid id, string fullName, string email, string passwordHash, DateTime createdAt) =>
            new(UserId.From(id), UserName.From(fullName), UserEmail.From(email), PasswordHash.From(passwordHash), UserCreatedAt.From(createdAt));
    }
}
