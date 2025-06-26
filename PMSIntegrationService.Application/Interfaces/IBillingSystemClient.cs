using PMIntegrationService.Core.Entities;

namespace PMSIntegrationService.Application.Interfaces;

public interface IBillingSystemClient
{
    Task<bool> CreatePatientAsync(Patient patient);
    Task<bool> UpdatePatientAsync(string patientId, Patient patient);
    Task<bool> SubmitBillingInfoAsync(string patientId, BillingInfo billingInfo);
    Task<bool> SubmitInsuranceClaimAsync(string patientId, Insurance insurance, IEnumerable<Charge> charges);
}