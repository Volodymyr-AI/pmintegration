namespace DataConnection.Models.OpenDental;

public class OpenDentalPatient
{
    public int PatNum { get; set; }
    public string LName { get; set; } = string.Empty;
    public string FName { get; set; } = string.Empty;
    public string MiddleI { get; set; } = string.Empty;
    public string Preferred { get; set; } = string.Empty;
    public string PatStatus { get; set; } = string.Empty;
    public string Birthdate { get; set; } = string.Empty; // "1980-06-05"
    public string SSN { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
    public string HmPhone { get; set; } = string.Empty;
    public string WkPhone { get; set; } = string.Empty;
    public string WirelessPhone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PriProvAbbr { get; set; } = string.Empty;
    public string SecProvAbbr { get; set; } = string.Empty;
    public string BillingType { get; set; } = string.Empty;
    public string ChartNumber { get; set; } = string.Empty;
    public int ClinicNum { get; set; }
    public string ClinicAbbr { get; set; } = string.Empty;
    public string SiteDesc { get; set; } = string.Empty;
    public string TxtMsgOk { get; set; } = string.Empty;
}