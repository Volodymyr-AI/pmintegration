using PMIntegrationService.Core.Enums;

namespace PMIntegrationService.Core.Entities;

public class Payment
{
    public string Id { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
    public string ReferenceNumber { get; set; }
    public string Note { get; set; }
}