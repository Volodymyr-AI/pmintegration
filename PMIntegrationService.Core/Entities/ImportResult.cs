namespace PMIntegrationService.Core.Entities;

public class ImportResult
{
    public bool Success { get; set; }
    public string ImportId { get; set; }
    public string ErrorMessage { get; set; }
    public List<string> Warnings { get; set; } = new();
    public DateTime ImportedAt { get; set; }
    public int ProcessedCount { get; set; }
    public Dictionary<string, object> AdditionalData { get; set; } = new();
}