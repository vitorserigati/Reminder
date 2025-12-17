using Reminder.Domain.Entities;

namespace Reminder.Application.Interfaces;

public interface ITokenProvider
{
    string Create(User user);
}
