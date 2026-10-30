using Hopli.Commands;
using Kommand.Abstractions;

namespace Hopli.Handlers;

public class AddAutoStartCommandHandler : ICommandHandler<AddAutoStartCommand, bool>
{
    public Task<bool> HandleAsync(AddAutoStartCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}