using Microsoft.Extensions.Logging;
using PMIntegrationService.Core.Enums;
using PMSIntegrationService.Application.Exceptions;
using PMSIntegrationService.Application.Interfaces;
using PMSIntegrationService.Application.Models;

namespace DataConnection.Adapters;

public abstract class BasePMSystemAdapter : IPMSystemAdapter
{
    protected readonly ILogger<BasePMSystemAdapter> _logger;
    protected PMConnectionConfig _connectionConfig;
    protected bool _isConnected = false;
    
    public abstract PMSystemType SystemType { get; }
    public abstract string Version { get; }
}