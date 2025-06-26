using PMIntegrationService.Core.Enums;

namespace PMIntegrationService.Core.Entities;

public class Charge
{
    public string Id { get; set; }
    public DateTime ServiceDate { get; set; }
    public string ProcedureCode { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string ProviderId { get; set; }
    public ChargeStatus Status { get; set; }
}