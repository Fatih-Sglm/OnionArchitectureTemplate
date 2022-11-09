namespace Application.Commons.Models.LoginModels;

public class AccessToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}