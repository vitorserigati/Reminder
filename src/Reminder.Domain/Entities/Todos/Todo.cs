using Reminder.Domain.ValueObjects.Todos;
using Reminder.Domain.ValueObjects.Users;

namespace Reminder.Domain.Entities;

public sealed record Todo(TodoId Id, UserId Owner, TodoState State, TodoTitle Title, TodoDescription Description, TodoCreationTime CreatedAt, TodoDueTime DueDate);
