using Kommand.Abstractions;

namespace Hopli.Commands;

public sealed record ExecutePayloadCommand(string payloadPath) : ICommand<bool>;