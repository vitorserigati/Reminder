namespace Reminder.Application.Interfaces;

public interface IMediator
{
    Task Send(ICommand command, CancellationToken ct = default);
    Task<TResponse> Query<TResponse>(IQuery<TResponse> query, CancellationToken ct = default);
}
