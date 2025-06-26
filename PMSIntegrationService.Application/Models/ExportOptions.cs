using PMSIntegrationService.Application.Enums;

namespace PMSIntegrationService.Application.Models;

public class ExportOptions
{
    public bool IncludeBilling { get; set; } = true;
    public bool IncludeInsurance { get; set; } = true;
    public bool IncludeCharges { get; set; } = true;
    public bool IncludePayments { get; set; } = true;
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public ExportFormat Format { get; set; } = ExportFormat.Json;
    public bool EncryptData { get; set; } = true;
}