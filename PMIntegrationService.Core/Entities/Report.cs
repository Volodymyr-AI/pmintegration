using PMIntegrationService.Core.Enums;

namespace PMIntegrationService.Core.Entities;

public class Report
{
    public string Id { get; set; }
    public string PatientId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ReportType Type { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public byte[] Content { get; set; }
    public string MimeType { get; set; }
    public string FileName { get; set; }
    public ReportCategory Category { get; set; }
    public Dictionary<string, object> Metadata { get; set; } = new();
}