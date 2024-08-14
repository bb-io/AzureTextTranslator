using Apps.MicrosoftTranslator.Constants;
using Azure;
using Azure.AI.Translation.Document;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;

namespace Apps.AzureTranslator.Api;

public class SingleDocumentTranslationClient  : DocumentTranslationClient
{
    public const string endpoint = "https://okapitestingblackbird.cognitiveservices.azure.com";
    
    public SingleDocumentTranslationClient (AuthenticationCredentialsProvider[] creds) 
        : base(new Uri(endpoint), new AzureKeyCredential(new(creds.Get(CredsNames.ApiKey).Value)))
    {
    }
}