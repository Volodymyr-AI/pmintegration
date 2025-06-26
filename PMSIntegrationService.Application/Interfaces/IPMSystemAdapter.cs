using PMIntegrationService.Core.Entities;
using PMIntegrationService.Core.Enums;
using PMSIntegrationService.Application.Models;
using ExportOptions = System.Runtime.Serialization.ExportOptions;

namespace PMSIntegrationService.Application.Interfaces;

public interface IPMSystemAdapter
{
    /// <summary>
    /// Import and export change
    /// </summary>
    PMSystemType SystemType { get; }
    string Version { get; }
    bool IsConnected { get; }
    
    // Connection management
    Task<bool> ConnectAsync(PMConnectionConfig config);
    Task DisconnectAsync();
    Task<bool> TestConnectionAsync();
    
    // Patient Data Export (PM -> External Billing )
    Task<Patient> GetPatientAsync(string patientId);
    Task<IEnumerable<Patient>> GetPatientsAsync(PatientSearchCriteria criteria);
    Task<BillingInfo> GetPatientBillingInfoAsync(string patientId);
    Task<IEnumerable<Insurance>> GetPatientInsuranceAsync(string patientId);
    Task<ExportResult> ExportPatientDataAsync(string patientId, ExportOptions options);
    Task<ExportResult> ExportPatientsBatchAsync(IEnumerable<string> patientIds, ExportOptions options);

    // Report Import (External → PM)
    Task<ImportResult> ImportReportAsync(string patientId, Report report);
    Task<ImportResult> ImportReportsBatchAsync(Dictionary<string, List<Report>> patientReports);
    Task<ImportResult> ImportReportFromFileAsync(string patientId, string filePath, ReportImportOptions options);

    // System Information
    Task<PMSystemInfo> GetSystemInfoAsync();
    Task<IEnumerable<string>> GetSupportedReportTypesAsync();
    Task<PMSystemCapabilities> GetCapabilitiesAsync();
}