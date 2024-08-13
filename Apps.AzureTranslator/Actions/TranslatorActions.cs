using System.Text;
using Apps.MicrosoftTranslator.Invocables;
using Apps.MicrosoftTranslator.Model;
using Apps.MicrosoftTranslator.Model.Request;
using Apps.MicrosoftTranslator.Model.Response;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;

namespace Apps.MicrosoftTranslator.Actions;

[ActionList]
public class TranslatorActions : AzureTextTranslatorInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public TranslatorActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("Translate", Description = "Translate text")]
    public async Task<TranslationResponse> Translate([ActionParameter] TextTranslationInput input)
    {
        var response = await Client.TranslateAsync(input.TargetLanguage, input.Text, input.SourceLanguage);
        return new(response);
    }

    [Action("Translate document", Description = "Translate content of the file")]
    public async Task<FileTranslationResponse> TranslateDocument([ActionParameter] FileModel file,
        [ActionParameter] TranslationInput input)
    {
        var fileStream = await _fileManagementClient.DownloadAsync(file.File);
        var fileString = Encoding.UTF8.GetString(await fileStream.GetByteData());

        var response = await Client.TranslateAsync(input.TargetLanguage, fileString, input.SourceLanguage);

        var translation = response.Value.First().Translations.First();

        return new(response, await _fileManagementClient.UploadAsync(
            new MemoryStream(Encoding.UTF8.GetBytes(translation.Text)), file.File.ContentType,
            file.File.Name));
    }

    [Action("Transliterate", Description = "Transliterate text")]
    public async Task<TransliterationResponse> Transliterate([ActionParameter] TransliterationInput input)
    {
        var response =
            await Client.TransliterateAsync(input.SourceLanguage, input.FromScript, input.ToScript, input.Text);
        return new(response);
    }
}