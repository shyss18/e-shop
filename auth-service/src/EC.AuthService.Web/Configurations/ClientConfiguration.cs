namespace EC.AuthService.Web.Configurations;

public class ClientConfiguration
{
    public string[] RedirectUris { get; set; }

    public string[] PostLogoutRedirectUris { get; set; }
}