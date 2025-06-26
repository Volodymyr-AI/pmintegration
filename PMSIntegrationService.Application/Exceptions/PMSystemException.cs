using PMIntegrationService.Core.Enums;

namespace PMSIntegrationService.Application.Exceptions;

public class PMSystemException : Exception
{
    public PMSystemType SystemType { get; }
    public string ErrorCode { get; }

    public PMSystemException(PMSystemType systemType, string message, string errorCode = null) : base(message)
    {
        SystemType = systemType;
        ErrorCode = errorCode;
    }

    public PMSystemException(PMSystemType systemType, string message, Exception innerException, string errorCode = null) 
        : base(message, innerException)
    {
        SystemType = systemType;
        ErrorCode = errorCode;
    }

    public class PMConnectionException : PMSystemException
    {
        public PMConnectionException(PMSystemType systemType, string message) : base(systemType, message, "CONNECTION_ERROR"){ }
    }
    
    public class PMAuthenticationException : PMSystemException
    {
        public PMAuthenticationException(PMSystemType systemType, string message) 
            : base(systemType, message, "AUTH_ERROR") { }
    }

    public class PMDataValidationException : PMSystemException
    {
        public PMDataValidationException(PMSystemType systemType, string message) 
            : base(systemType, message, "VALIDATION_ERROR") { }
    }
}