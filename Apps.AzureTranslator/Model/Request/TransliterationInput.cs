using Apps.MicrosoftTranslator.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.MicrosoftTranslator.Model.Request;

public class TransliterationInput
{
    [Display("Source language")]
    [DataSource(typeof(TransliterationLanguageDataHandler))]
    public string SourceLanguage { get; set; } = null!;

    public string Text { get; set; } = null!;

    [Display("Source script", Description = "Specifies the script used by the input text.")]
    [DataSource(typeof(TransliterationScriptDataHandler))]
    public string FromScript { get; set; } = null!;

    [Display("Target script", Description = "Specifies the output script. ")]
    [DataSource(typeof(TransliterationScriptDataHandler))]
    public string ToScript { get; set; } = null!;
}