using Microsoft.Extensions.Logging;
using PMIntegrationService.Core.Enums;
using PMSIntegrationService.Application.Exceptions;
using PMSIntegrationService.Application.Interfaces;
using PMSIntegrationService.Application.Models;

namespace DataConnection.Adapters;

public abstract class BasePMSystemAdapter
{
    protected readonly ILogger<BasePMSystemAdapter>? _logger;
    protected PMConnectionConfig? _connectionConfig;
    protected bool _isConnected = false;
    
    public abstract PMSystemType SystemType { get; }
    public abstract string Version { get; }

    protected BasePMSystemAdapter()
    {
        // Parameterless constructor for derived classes
    }

    protected BasePMSystemAdapter(ILogger<BasePMSystemAdapter> logger)
    {
        _logger = logger;
    }
}