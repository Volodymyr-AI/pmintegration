using PMIntegrationService.Core.Entities;
using PMIntegrationService.Core.Enums;
using PMSIntegrationService.Application.Models;

namespace PMSIntegrationService.Application.Interfaces;

public interface IPMIntegrationService
{
    Task<ExportResult> ExportPatientDataAsync(PMSystemType systemType, string patientId, string destinationEndpoint);
    Task<ImportResult> ImportReportAsync(PMSystemType systemType, string patientId, Report report);
    Task<IEnumerable<PMSystemInfo>> GetAvailableSystemsAsync();
    Task<bool> ValidateSystemConnectionAsync(PMSystemType systemType, PMConnectionConfig config);
}