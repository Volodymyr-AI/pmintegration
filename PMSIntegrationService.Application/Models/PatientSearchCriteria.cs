namespace PMSIntegrationService.Application.Models;

public class PatientSearchCriteria
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirthFrom { get; set; }
    public DateTime? DateOfBirthTo { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime? ModifiedSince { get; set; }
    public int MaxResults { get; set; } = 100;
    public int Offset { get; set; } = 0;
}