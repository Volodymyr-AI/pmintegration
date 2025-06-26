using PMIntegrationService.Core.Enums;
using PMSIntegrationService.Application.Models;

namespace PMSIntegrationService.Application.Interfaces;

public interface IPMSystemAdapterFactory
{
    IPMSystemAdapter CreateAdapter(PMSystemType systemType);
    IPMSystemAdapter CreateAdapter(PMConnectionConfig config);
    IEnumerable<PMSystemType> GetSupportedSystems();
    bool IsSystemSupported(PMSystemType systemType);
}