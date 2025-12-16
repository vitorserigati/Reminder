using Reminder.Application.Interfaces;

namespace Reminder.Infrastructure;

public sealed class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceP) => _serviceProvider = serviceP;

    public async Task<TResponse> Query<TResponse>(IQuery<TResponse> query, CancellationToken ct = default)
    {
        Type handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType());
        dynamic handler = _serviceProvider.GetService(handlerType)
            ?? throw new InvalidOperationException($"No handler found for query: {query.GetType().Name}");

        return await handler.Handle((dynamic)query, ct);
    }

    public async Task Send(ICommand command, CancellationToken ct = default)
    {
        Type handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());

        dynamic handler = _serviceProvider.GetService(handlerType)
            ?? throw new InvalidOperationException($"No handler found for command: {command.GetType().Name}");

        await handler.Handle((dynamic)command, ct);
    }
}
