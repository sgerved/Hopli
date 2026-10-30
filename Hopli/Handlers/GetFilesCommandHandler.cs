using Hopli.Commands;
using Kommand.Abstractions;

namespace Hopli.Handlers;

public class GetFilesCommandHandler : ICommandHandler<GetFilesCommand, List<string>>
{
    public Task<List<string>> HandleAsync(GetFilesCommand command, CancellationToken cancellationToken)
    {
        var files = Directory.GetFiles(command.Path);
        return Task.FromResult(files.ToList());
    }
}