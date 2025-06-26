using PMIntegrationService.Core.Enums;

namespace PMSIntegrationService.Application.Models;

public class PMSystemInfo
{
    public PMSystemType Type { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public string Vendor { get; set; }
    public DateTime? LastSyncTime { get; set; }
    public bool IsOnline { get; set; }
    public string ConnectionString { get; set; }
    public PMSystemCapabilities Capabilities { get; set; }
}