namespace OnlineAccounting.Domain.Results;

public sealed class ValidationErrorResult
{
    public IEnumerable<string> Errors { get; set; }
}