using Apps.AzureTranslator.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AzureTranslator.Model.Request;

public class TransliterationInput
{
    [Display("Source language")]
    [DataSource(typeof(TransliterationLanguageDataHandler))]
    public string SourceLanguage { get; set; }

    public string Text { get; set; }

    [Display("Source script")]
    [DataSource(typeof(TransliterationScriptDataHandler))]
    public string FromScript { get; set; }

    [Display("Target script")]
    [DataSource(typeof(TransliterationScriptDataHandler))]
    public string ToScript { get; set; }
}