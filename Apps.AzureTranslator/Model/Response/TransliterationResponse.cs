using Azure;
using Azure.AI.Translation.Text;
using Blackbird.Applications.Sdk.Common;

namespace Apps.AzureTranslator.Model.Response;

public class TransliterationResponse
{
    [Display("Transliterated text")] public string TransliteratedText { get; set; }

    public TransliterationResponse(Response<IReadOnlyList<TransliteratedText>> response)
    {
        TransliteratedText = response.Value.First().Text;
    }
}