using System.Globalization;
using DataConnection.Models.OpenDental;
using PMIntegrationService.Core.Entities;

namespace DataConnection.Mappers;

public class OpenDentalMapper
{
    public static Patient MapToPatient(OpenDentalPatient odPatient)
    {
        var patient = new Patient
        {
            Id = odPatient.PatNum.ToString(),
            FirstName = odPatient.FName ?? string.Empty,
            LastName = odPatient.LName ?? string.Empty,
            Email = odPatient.Email ?? string.Empty,
            Phone = GetPrimaryPhone(odPatient),
            Address = MapToAddress(odPatient),
            SocialSecurityNumber = odPatient.SSN ?? string.Empty,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };

        // Parse birthdate
        if (!string.IsNullOrEmpty(odPatient.Birthdate) && 
            DateTime.TryParseExact(odPatient.Birthdate, "yyyy-MM-dd", 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var birthDate))
        {
            patient.DateOfBirth = birthDate;
        }

        return patient;
    }

    public static Address MapToAddress(OpenDentalPatient odPatient)
    {
        var address = new Address
        {
            Street = odPatient.Address ?? string.Empty,
            City = odPatient.City ?? string.Empty,
            State = odPatient.State ?? string.Empty,
            ZipCode = odPatient.Zip ?? string.Empty,
            Country = "US" // Default for US dental practices
        };

        // Combine Address and Address2 if both exist
        if (!string.IsNullOrEmpty(odPatient.Address2))
        {
            address.Street = $"{address.Street} {odPatient.Address2}".Trim();
        }

        return address;
    }

    public static string GetPrimaryPhone(OpenDentalPatient odPatient)
    {
        // Priority: Home -> Wireless -> Work
        if (!string.IsNullOrEmpty(odPatient.HmPhone))
            return CleanPhoneNumber(odPatient.HmPhone);
        
        if (!string.IsNullOrEmpty(odPatient.WirelessPhone))
            return CleanPhoneNumber(odPatient.WirelessPhone);
        
        if (!string.IsNullOrEmpty(odPatient.WkPhone))
            return CleanPhoneNumber(odPatient.WkPhone);

        return string.Empty;
    }

    private static string CleanPhoneNumber(string phone)
    {
        if (string.IsNullOrEmpty(phone)) return string.Empty;
        
        // Remove common phone formatting characters
        return phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();
    }

    // For future use - reverse mapping if needed
    public static OpenDentalPatient MapFromPatient(Patient patient)
    {
        return new OpenDentalPatient
        {
            PatNum = int.TryParse(patient.Id, out var patNum) ? patNum : 0,
            FName = patient.FirstName,
            LName = patient.LastName,
            Email = patient.Email,
            HmPhone = patient.Phone,
            Address = patient.Address?.Street ?? string.Empty,
            City = patient.Address?.City ?? string.Empty,
            State = patient.Address?.State ?? string.Empty,
            Zip = patient.Address?.ZipCode ?? string.Empty,
            SSN = patient.SocialSecurityNumber,
            Birthdate = patient.DateOfBirth.ToString("yyyy-MM-dd")
        };
    }
}