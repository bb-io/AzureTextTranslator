using Azure;
using Azure.AI.Translation.Text;
using Blackbird.Applications.Sdk.Common;

namespace Apps.AzureTranslator.Model.Response;

public class TranslationResponse
{
    [Display("Translated text")] public string TranslatedText { get; set; }

    [Display("Target language")] public string TargetLanguage { get; set; }

    [Display("Detected source language")] public string DetectedSourceLanguage { get; set; }

    [Display("Source language detecting score")]
    public float SourceLanguageDetectingScore { get; set; }

    public TranslationResponse(Response<IReadOnlyList<TranslatedTextItem>> response)
    {
        var translation = response.Value.First().Translations.First();
        var detectedLanguage = response.Value.First().DetectedLanguage;

        TranslatedText = translation.Text;
        TargetLanguage = translation.To;
        DetectedSourceLanguage = detectedLanguage.Language;
        SourceLanguageDetectingScore = detectedLanguage.Score;
    }
}