using PMIntegrationService.Core.Enums;
using PMSIntegrationService.Application.Enums;

namespace PMSIntegrationService.Application.Models;

public class PMSystemCapabilities
{
    public bool SupportsPatientExport { get; set; }
    public bool SupportsReportImport { get; set; }
    public bool SupportsBatchOperations { get; set; }
    public bool SupportsRealTimeSync { get; set; }
    public bool SupportsEncryption { get; set; }
    public IEnumerable<ReportType> SupportedReportTypes { get; set; }
    public IEnumerable<ExportFormat> SupportedExportFormats { get; set; }
    public int MaxBatchSize { get; set; }
    public TimeSpan MaxOperationTimeout { get; set; }
}