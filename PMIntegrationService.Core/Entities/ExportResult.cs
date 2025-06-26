namespace PMIntegrationService.Core.Entities;

public class ExportResult
{
    public bool Success { get; set; }
    public string ExportId { get; set; }
    public string ErrorMessage { get; set; }
    public DateTime ExportedAt { get; set; }
    public int RecordCount { get; set; }
    public long FileSizeBytes { get; set; }
    public string ExportPath { get; set; }
}