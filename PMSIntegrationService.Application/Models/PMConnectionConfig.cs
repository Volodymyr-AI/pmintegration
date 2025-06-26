using PMIntegrationService.Core.Enums;

namespace PMSIntegrationService.Application.Models;

public class PMConnectionConfig
{
    public PMSystemType SystemType { get; set; }
    public string ServerName { get; set; }
    public string DatabaseName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ApiKey { get; set; }
    public string ApiSecret { get; set; }
    public string BaseUrl { get; set; }
    public int Port { get; set; } = 3306;
    public int TimeoutSeconds { get; set; } = 30;
    public bool UseSSL { get; set; } = true;
    public Dictionary<string, string> AdditionalSettings { get; set; } = new();
}