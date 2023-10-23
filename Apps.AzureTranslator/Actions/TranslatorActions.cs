using Apps.AzureTranslator.Invocables;
using Apps.AzureTranslator.Model.Request;
using Apps.AzureTranslator.Model.Response;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AzureTranslator.Actions;

[ActionList]
public class TranslatorActions : AzureTextTranslatorInvocable
{
    public TranslatorActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Translate", Description = "Translate text")]
    public async Task<TranslationResponse> Translate([ActionParameter] TranslationInput input)
    {
        var response = await Client.TranslateAsync(input.TargetLanguage, input.Text, input.SourceLanguage);
        return new(response);
    }
    
    [Action("Transliterate", Description = "Transliterate text")]
    public async Task<TransliterationResponse> Transliterate([ActionParameter] TransliterationInput input)
    {
        var response = await Client.TransliterateAsync(input.SourceLanguage, input.FromScript, input.ToScript, input.Text);
        return new(response);
    }
}