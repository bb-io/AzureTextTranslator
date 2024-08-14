using Apps.MicrosoftTranslator.Constants;
using Apps.MicrosoftTranslator.Invocables;
using Apps.MicrosoftTranslator.Model;
using Apps.MicrosoftTranslator.Model.Request;
using Apps.MicrosoftTranslator.Model.Response;
using Apps.MicrosoftTranslator.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using RestSharp;

namespace Apps.MicrosoftTranslator.Actions;

[ActionList]
public class TranslatorActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient)
    : AzureTextTranslatorInvocable(invocationContext)
{
    [Action("Translate", Description = "Translate text")]
    public async Task<TranslationResponse> Translate([ActionParameter] TextTranslationInput input)
    {
        var response = await Client.TranslateAsync(input.TargetLanguage, input.Text, input.SourceLanguage);
        return new(response);
    }

    [Action("Translate document", Description = "Translate content of the file")]
    public async Task<TranslateDocumentResponse> TranslateDocument([ActionParameter] FileModel file,
        [ActionParameter] TranslationInput input)
    {
        var url = Creds.GetDocumentTranslationUrl();
        var key = Creds.Get(CredsNames.ApiKey).Value;
    
        var fileStream = await fileManagementClient.DownloadAsync(file.File);
        var bytes = await fileStream.GetByteData();
        var options = new RestClientOptions(url)
        {
            MaxTimeout = -1,
        };
        
        var client = new RestClient(options);
        
        var requestUrl = $"/translator/document:translate?targetLanguage={input.TargetLanguage}&api-version=2024-05-01";
        if (!string.IsNullOrEmpty(input.SourceLanguage))
        {
            requestUrl += $"&sourceLanguage={input.SourceLanguage}";
        }
        var request = new RestRequest(requestUrl, Method.Post);
        request.AddHeader("Ocp-Apim-Subscription-Key", key);
        request.AlwaysMultipartFormData = true;
        request.AddFile("document", bytes, file.File.Name, file.File.ContentType);
    
        var response = await client.ExecuteAsync(request);
        if (!response.IsSuccessful)
        {
            throw response.GetException();
        }
    
        var byteResponse = response.RawBytes!;
        var memoryStream = new MemoryStream(byteResponse);
        memoryStream.Position = 0;
        var fileReference = await fileManagementClient.UploadAsync(memoryStream, file.File.ContentType, file.File.Name);
        return new()
        {
            File = fileReference
        };
    }

    [Action("Transliterate", Description = "Transliterate text")]
    public async Task<TransliterationResponse> Transliterate([ActionParameter] TransliterationInput input)
    {
        var response =
            await Client.TransliterateAsync(input.SourceLanguage, input.FromScript, input.ToScript, input.Text);
        return new(response);
    }
}