using Apps.AzureTranslator.Constants;
using Azure;
using Azure.AI.Translation.Document;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;

namespace Apps.AzureTranslator.Api;

public class AzureDocumentTranslatorClient : DocumentTranslationClient
{
    public const string endpoint = "https://api.cognitive.microsofttranslator.com";
    
    public AzureDocumentTranslatorClient(AuthenticationCredentialsProvider[] creds) 
        : base(new Uri(endpoint), new AzureKeyCredential(new(creds.Get(CredsNames.ApiKey).Value)))
    {
        
    }
}