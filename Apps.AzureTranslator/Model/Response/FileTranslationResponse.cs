using Azure;
using Azure.AI.Translation.Text;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.MicrosoftTranslator.Model.Response;

public class FileTranslationResponse
{
    [Display("Translated file")] public FileReference File { get; set; }

    [Display("Target language")] public string TargetLanguage { get; set; }

    [Display("Detected source language")] public string DetectedSourceLanguage { get; set; }

    [Display("Source language detecting score")]
    public float SourceLanguageDetectingScore { get; set; }

    public FileTranslationResponse(Response<IReadOnlyList<TranslatedTextItem>> response, FileReference file)
    {
        var translation = response.Value.First().Translations.First();
        var detectedLanguage = response.Value.First().DetectedLanguage;

        File = file;
        TargetLanguage = translation.To;
        DetectedSourceLanguage = detectedLanguage.Language;
        SourceLanguageDetectingScore = detectedLanguage.Score;
    }
}