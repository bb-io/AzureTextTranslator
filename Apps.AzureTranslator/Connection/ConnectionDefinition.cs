using Apps.MicrosoftTranslator.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.MicrosoftTranslator.Connection;

public class ConnectionDefinition : IConnectionDefinition
{
    public IEnumerable<ConnectionPropertyGroup> ConnectionPropertyGroups => new List<ConnectionPropertyGroup>()
    {
        new()
        {
            Name = "Developer API token",
            AuthenticationType = ConnectionAuthenticationType.Undefined,
            ConnectionUsage = ConnectionUsage.Actions,
            ConnectionProperties = new List<ConnectionProperty>()
            {
                new(CredsNames.DocumentTranslationUrl)
                {
                    DisplayName = "Document translation endpoint",
                    Description =
                        "We expect something like this: https://<NAME-OF-YOUR-RESOURCE>.cognitiveservices.azure.com",
                    Sensitive = false
                },   
                new(CredsNames.Region) { DisplayName = "Location/Region", },
                new(CredsNames.ApiKey) { DisplayName = "API key", Sensitive = true }
            }
        }
    };

    public IEnumerable<AuthenticationCredentialsProvider> CreateAuthorizationCredentialsProviders(
        Dictionary<string, string> values)
    {
        yield return new AuthenticationCredentialsProvider(
            AuthenticationCredentialsRequestLocation.None,
            CredsNames.ApiKey,
            values[CredsNames.ApiKey]
        );

        yield return new AuthenticationCredentialsProvider(
            AuthenticationCredentialsRequestLocation.None,
            CredsNames.Region,
            values[CredsNames.Region]
        );
        
        yield return new AuthenticationCredentialsProvider(
            AuthenticationCredentialsRequestLocation.None,
            CredsNames.DocumentTranslationUrl,
            values[CredsNames.DocumentTranslationUrl]
        );
    }
}