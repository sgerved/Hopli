using Hopli.Commands;
using Kommand.Abstractions;

namespace Hopli.Handlers;

public class DownloadPayloadCommandHandler(IHttpClientFactory clientFactory)
    : ICommandHandler<DownloadPayloadCommand, bool>
{
    public async Task<bool> HandleAsync(DownloadPayloadCommand command, CancellationToken cancellationToken)
    {
        var client = clientFactory.CreateClient();
        try
        {
            var payload = await client.GetAsync(command.PayloadPath, cancellationToken);
            var payloadContent = await payload.Content.ReadAsByteArrayAsync(cancellationToken);
            await File.WriteAllBytesAsync(command.OutputPath + "\\" + command.OutputFileName, payloadContent, cancellationToken);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }
        return await Task.FromResult(true);
    }
}