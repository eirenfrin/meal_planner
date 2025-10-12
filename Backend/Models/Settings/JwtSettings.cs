namespace Backend.Models.Settings;

public class JwtSettings
{
    public string Issuer { get; set; } = null!;

    public string Audience { get; set; } = null!;

    public string SigningKey { get; set; } = null!;
}