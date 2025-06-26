namespace PMIntegrationService.Core.Entities;

public class BillingInfo
{
    public string PatientId { get; set; }
    public decimal TotalCharges { get; set; }
    public decimal TotalPayments { get; set; }
    public decimal Balance { get; set; }
    public List<Charge> Charges { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();
    public DateTime LastBillingDate { get; set; }
}