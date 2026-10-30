using Kommand.Abstractions;

namespace Hopli.Commands;

public sealed record AddAutoStartCommand(string Path, AutoStartOptions Options) : ICommand<bool>;