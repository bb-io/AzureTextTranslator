using Apps.MicrosoftTranslator.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.MicrosoftTranslator.Model.Request;

public class TranslationInput
{
    [Display("Target language")]
    [DataSource(typeof(TranslationLanguageDataHandler))]
    public string TargetLanguage { get; set; }

    [Display("Source language")]
    [DataSource(typeof(TranslationLanguageDataHandler))]
    public string? SourceLanguage { get; set; }
}