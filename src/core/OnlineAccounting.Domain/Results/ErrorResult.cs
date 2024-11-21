using System.Text.Json;

namespace OnlineAccounting.Domain.Results;

public sealed class ErrorResult(string message)
{
    public string Message { get; set; } = message;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}