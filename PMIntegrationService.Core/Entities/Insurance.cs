using PMIntegrationService.Core.Enums;

namespace PMIntegrationService.Core.Entities;

public class Insurance
{
    public string Id { get; set; }
    public string CarrierName { get; set; }
    public string PolicyNumber { get; set; }
    public string GroupNumber { get; set; }
    public string SubscriberId { get; set; }
    public string SubscriberName { get; set; }
    public InsuranceType Type { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public decimal? MaxBenefit { get; set; }
    public decimal? Deductible { get; set; }
    public decimal? DeductibleMet { get; set; }
}