using Backend.Models.Settings;

namespace Backend.Extensions;

public static class ConfigurationManagerExtensions
{
    public static DatabaseSettings GetDatabaseSettings(this ConfigurationManager configuration)
    {
        var dbSettings = configuration.GetSection("DB").Get<DatabaseSettings>();

        if (dbSettings == null)
        {
            throw new InvalidOperationException("Database configuration section 'DB' is missing or invalid.");
        }

        return dbSettings;
    }

    public static JwtSettings GetJwtSettings(this ConfigurationManager configuration)
    {
        var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();

        if (jwtSettings == null)
        {
            throw new InvalidOperationException("JWT configuration section 'Jwt' is missing or invalid.");
        }

        return jwtSettings;
    }

    public static CorsSettings GetCorsSettings(this ConfigurationManager configuration)
    {
        var corsSettings = configuration.GetSection("Cors").Get<CorsSettings>();

        if (corsSettings == null)
        {
            throw new InvalidOperationException("CORS configuration section 'Cors' is missing or invalid.");
        }

        return corsSettings;
    }
}