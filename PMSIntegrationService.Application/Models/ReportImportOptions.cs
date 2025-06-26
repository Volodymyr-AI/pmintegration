using PMIntegrationService.Core.Enums;

namespace PMSIntegrationService.Application.Models;

public class ReportImportOptions
{
    public ReportCategory Category { get; set; }
    public string ProviderId { get; set; }
    public bool CreatePatientIfNotExists { get; set; } = false;
    public bool OverwriteExisting { get; set; } = false;
    public Dictionary<string, object> CustomMetadata { get; set; } = new();
}