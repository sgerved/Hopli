using Kommand.Abstractions;

namespace Hopli.Commands;

public sealed record GetFilesCommand(string Path) : ICommand<List<string>>;