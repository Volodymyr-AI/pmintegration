namespace PMIntegrationService.Core.Entities;

public class Patient
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public string SocialSecurityNumber { get; set; }
    public List<Insurance> Insurances { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}