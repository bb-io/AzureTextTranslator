using Apps.MicrosoftTranslator.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.MicrosoftTranslator.Model.Request;

public class TranslationInput
{
    [Display("Target language")]
    [DataSource(typeof(TranslationLanguageDataHandler))]
    public string TargetLanguage { get; set; } = null!;

    [Display("Source language")]
    [DataSource(typeof(TranslationLanguageDataHandler))]
    public string? SourceLanguage { get; set; }
    
    [Display("Allow fallback", Description = "Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist. Possible values are: true (default) or false.")]
    public bool? AllowFallback { get; set; }
    
    [Display("Category", Description = "A string specifying the category (domain) of the translation. This parameter is used to get translations from a customized system built with Custom Translator. Default value is: general.")]
    public string? Category { get; set; }
}