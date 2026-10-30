using Kommand.Abstractions;

namespace Hopli.Commands;

public sealed record DownloadPayloadCommand(string PayloadPath, string OutputPath, string OutputFileName) : ICommand<bool>;