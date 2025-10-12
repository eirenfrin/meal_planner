using System.Data.Common;

namespace Backend.Models.Settings;

public class DatabaseSettings
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Port { get; set; } = null!;

    public string Host { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string ConnectionString => $"Host={Host};Port={Port};Database={Name};Username={Username};Password={Password};SSL Mode=Require;Trust Server Certificate=true";
}