using Reminder.Domain.ValueObjects.Todos;
using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Domain.Entities;

public sealed record Todo(TodoId Id, UserId Owner, TodoState State, TodoTitle Title, TodoDescription Description, TodoCreationTime CreatedAt, TodoDueTime DueDate);

public static class TodoExtensions
{
    extension(Todo)
    {
        public static Todo CreateNew(Guid ownerId, int state, string title, string description, DateTime createdAt, DateTime dueDate) =>
            CreateValid(Guid.CreateVersion7(), ownerId, state, title, description, createdAt, dueDate);

        public static Todo Restore(Guid id, Guid ownerId, int state, string title, string description, DateTime createdAt, DateTime dueDate) =>
            CreateValid(id, ownerId, state, title, description, createdAt, dueDate);

        private static Todo CreateValid(Guid id, Guid ownerId, int state, string title, string description, DateTime createdAt, DateTime dueDate) =>
            new(TodoId.From(id),
                UserId.From(ownerId),
                (TodoState)state, TodoTitle.From(title),
                TodoDescription.From(description),
                TodoCreationTime.From(createdAt),
                TodoDueTime.From(dueDate));
    }
}

