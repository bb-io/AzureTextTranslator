using Apps.MicrosoftTranslator.DataSourceHandlers.Static;
using Azure.AI.Translation.Text;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.MicrosoftTranslator.Model.Request;

public class TextTranslationInput : TranslationInput
{
    public string Text { get; set; } = null!;

    [Display("Text type", Description = "Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed, complete element. Possible values are: plain (default) or html."), StaticDataSource(typeof(TextTypeStaticSource))]
    public string? TextType { get; set; }

    [Display("Profanity action", Description = "Specifies how profanities should be treated in translations. Possible values are: NoAction (default), Marked, or Deleted."), StaticDataSource(typeof(ProfanityActionStaticSource))]
    public string? ProfanityAction { get; set; }

    [Display("Profanity marker", Description = "Specifies how profanities should be marked in translations. Possible values are: Asterisk (default) or Tag."), StaticDataSource(typeof(ProfanityMarkerStaticSource))]
    public string? ProfanityMarker { get; set; }

    [Display("Include alignment", Description = "Specifies whether to include alignment projection from source text to translated text. Possible values are: true or false (default).")]
    public bool? IncludeAlignment { get; set; }

    [Display("Include sentence length", Description = "Specifies whether to include sentence boundaries for the input text and the translated text. Possible values are: true or false (default).")]
    public bool? IncludeSentenceLength { get; set; }

    [Display("Suggested from", Description = "Specifies a fallback language if the language of the input text can't be identified."), DataSource(typeof(TranslationLanguage))]
    public string? SuggestedFrom { get; set; }

    [Display("From script", Description = "Specifies the script of the input text.")]
    public string? FromScript { get; set; }

    [Display("To script", Description = "Specifies the script of the translated text.")]
    public string? ToScript { get; set; }
}