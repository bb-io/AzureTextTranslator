using Apps.AzureTranslator.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AzureTranslator.Model.Request;

public class TranslationInput
{
    public string Text { get; set; }

    [Display("Target language")]
    [DataSource(typeof(TranslationLanguageDataHandler))]
    public string TargetLanguage { get; set; }

    [Display("Source language")]
    [DataSource(typeof(TranslationLanguageDataHandler))]
    public string? SourceLanguage { get; set; }
}