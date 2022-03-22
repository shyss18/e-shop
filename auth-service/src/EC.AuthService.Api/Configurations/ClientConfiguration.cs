namespace EC.AuthService.Api.Configurations;

public class ClientConfiguration
{
    public string[] RedirectUris { get; set; }

    public string[] PostLogoutRedirectUris { get; set; }
}