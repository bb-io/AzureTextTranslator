using Apps.MicrosoftTranslator.Constants;
using Azure;
using Azure.AI.Translation.Text;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;

namespace Apps.MicrosoftTranslator.Api;

public class AzureTextTranslatorClient : TextTranslationClient
{
    public AzureTextTranslatorClient(AuthenticationCredentialsProvider[] creds) : base(GetCredentials(creds),
        GetRegion(creds))
    {
    }

    private static string GetRegion(AuthenticationCredentialsProvider[] creds)
        => creds.Get(CredsNames.Region).Value;

    private static AzureKeyCredential GetCredentials(AuthenticationCredentialsProvider[] creds)
        => new(creds.Get(CredsNames.ApiKey).Value);
}