namespace Apps.MicrosoftTranslator.Model.Dtos;

public class ErrorDto
{
    public Error Error { get; set; } = new();

    public override string ToString()
    {
        return $"Error code: {Error.Code}; Message: {Error.Message}";
    }
}

public class Error
{
    public string Code { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}