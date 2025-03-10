public class Config
{
    public static IEnumerable<ApiResource> GetApis()
    {
        return [new ApiResource("api", "Api Service")];
    }

    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return [new ApiScope("api", "Api Service")];
    }

    public static IEnumerable<IdentityResource> GetResources()
    {
        return [
            new IdentityResources.OpenId(),
                new IdentityResources.Profile()
        ];
    }

    public static IEnumerable<Client> GetClients(string frontendUrl)
    {
        return new List<Client>
            {
               new Client
               {
                   ClientId = "frontend",
                   ClientName = "FeedbackApp Frontend",
                   ClientSecrets = new List<Secret>(),
                   ClientUri = frontendUrl,
                   AllowedGrantTypes = GrantTypes.Code,
                   AllowAccessTokensViaBrowser = false,
                   RequireConsent = false,
                   AllowOfflineAccess = true,
                   AlwaysIncludeUserClaimsInIdToken = true,
                   RequirePkce = true,
                   RedirectUris = { $"{frontendUrl}/auth/callback" },
                   PostLogoutRedirectUris = { frontendUrl },
                   AllowedScopes = new List<string>
                   {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile,
                       IdentityServerConstants.StandardScopes.OfflineAccess,
                       "api",
                   },
                   AccessTokenLifetime = 60*60*2,
                   IdentityTokenLifetime= 60*60*2
               }
            };
    }
}