using PMIntegrationService.Core.Enums;

namespace PMSIntegrationService.Application.Models.PMS;

public static class OpenDentalConfig
{
    public static PMConnectionConfig CreateTestConfig()
    {
        return new PMConnectionConfig
        {
            SystemType = PMSystemType.OpenDental,
            BaseUrl = "http://localhost:30222",
            AuthToken = "NFF6i0KrXrxDkZHt/VzkmZEaUWOjnQX2z",
            AuthScheme = "ODFHIR",
            UseApi = true,
            TimeoutSeconds = 30
        };
    }
}