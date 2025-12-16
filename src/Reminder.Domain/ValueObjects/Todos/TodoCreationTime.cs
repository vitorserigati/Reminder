using ValueOf;

namespace Reminder.Domain.ValueObjects.Todos;

public sealed class TodoCreationTime : ValueOf<DateTime, TodoCreationTime>
{
    protected override void Validate()
    {
        if (Value > DateTime.UtcNow)
            throw new ArgumentException("Cannot create a todo on the future");
    }
}
