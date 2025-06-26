using PMIntegrationService.Core.Enums;

namespace PMSIntegrationService.Application.Models;

public class PMConnectionConfig
{
    public PMSystemType SystemType { get; set; }
    
    // API Configuration
    public string BaseUrl { get; set; } = string.Empty; // http://localhost:30222
    public string AuthToken { get; set; } = string.Empty; // NFF6i0KrXrxDkZHt/VzkmZEaUWOjnQX2z
    public string AuthScheme { get; set; } = "ODFHIR"; // OAuth scheme
    
    // Database Configuration (fallback for direct DB access)
    public string ServerName { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Port { get; set; } = 3306;
    
    // General Settings
    public int TimeoutSeconds { get; set; } = 30;
    public bool UseSSL { get; set; } = true;
    public bool UseApi { get; set; } = true; // Prefer API over direct DB
    
    // Additional Settings
    public Dictionary<string, string> AdditionalSettings { get; set; } = new();
    
    // Helper methods
    public bool IsApiConfigured => !string.IsNullOrEmpty(BaseUrl) && !string.IsNullOrEmpty(AuthToken);
    public bool IsDatabaseConfigured => !string.IsNullOrEmpty(ServerName) && !string.IsNullOrEmpty(DatabaseName);
}