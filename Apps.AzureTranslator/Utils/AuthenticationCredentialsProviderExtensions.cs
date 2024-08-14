using Apps.MicrosoftTranslator.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;

namespace Apps.MicrosoftTranslator.Utils;

public static class AuthenticationCredentialsProviderExtensions
{
    public static string GetDocumentTranslationUrl(this AuthenticationCredentialsProvider[] authenticationCredentialsProviders)
    {
        var url = authenticationCredentialsProviders.Get(CredsNames.DocumentTranslationUrl).Value;
        if (url.EndsWith("/"))
        {
            url = url.Substring(0, url.Length - 1);
        }
        
        return url;
    }
}