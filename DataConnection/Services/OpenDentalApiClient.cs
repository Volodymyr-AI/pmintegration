using System.Net.Http.Headers;
using System.Text.Json;
using DataConnection.Models.OpenDental;
using Microsoft.Extensions.Logging;

namespace DataConnection.Services;

public class OpenDentalApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<OpenDentalApiClient> _logger;
    private readonly JsonSerializerOptions _jsonOptions;

    public OpenDentalApiClient(HttpClient httpClient, ILogger<OpenDentalApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<bool> ConfigureAsync(string baseUrl, string authToken)
    {
        try
        {
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("ODFHIR", authToken);

            _logger.LogInformation($"OpenDental API client configured for {baseUrl}");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to configure OpenDental API client");
            return false;
        }
    }
    
    public async Task<OpenDentalApiResponse<List<OpenDentalPatient>>> GetPatientsAsync()
    {
        try
        {
            _logger.LogDebug("Fetching all patients from OpenDental API");
            
            var response = await _httpClient.GetAsync("/api/v1/patients");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var patients = JsonSerializer.Deserialize<List<OpenDentalPatient>>(content, _jsonOptions);
                
                _logger.LogInformation("Successfully retrieved {Count} patients", patients?.Count ?? 0);
                
                return new OpenDentalApiResponse<List<OpenDentalPatient>>
                {
                    Success = true,
                    Data = patients ?? new List<OpenDentalPatient>(),
                    StatusCode = (int)response.StatusCode
                };
            }
            else
            {
                _logger.LogWarning("Failed to retrieve patients. Status: {StatusCode}, Response: {Content}", 
                    response.StatusCode, content);
                
                return new OpenDentalApiResponse<List<OpenDentalPatient>>
                {
                    Success = false,
                    ErrorMessage = $"API call failed with status {response.StatusCode}: {content}",
                    StatusCode = (int)response.StatusCode
                };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception occurred while fetching patients");
            return new OpenDentalApiResponse<List<OpenDentalPatient>>
            {
                Success = false,
                ErrorMessage = ex.Message,
                StatusCode = 500
            };
        }
    }
    
    public async Task<OpenDentalApiResponse<OpenDentalPatient>> GetPatientAsync(int patNum)
    {
        try
        {
            _logger.LogDebug("Fetching patient {PatNum} from OpenDental API", patNum);
            
            var response = await _httpClient.GetAsync($"/api/v1/patients/{patNum}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var patient = JsonSerializer.Deserialize<OpenDentalPatient>(content, _jsonOptions);
                
                _logger.LogInformation("Successfully retrieved patient {PatNum}", patNum);
                
                return new OpenDentalApiResponse<OpenDentalPatient>
                {
                    Success = true,
                    Data = patient,
                    StatusCode = (int)response.StatusCode
                };
            }
            else
            {
                _logger.LogWarning("Failed to retrieve patient {PatNum}. Status: {StatusCode}, Response: {Content}", 
                    patNum, response.StatusCode, content);
                
                return new OpenDentalApiResponse<OpenDentalPatient>
                {
                    Success = false,
                    ErrorMessage = $"API call failed with status {response.StatusCode}: {content}",
                    StatusCode = (int)response.StatusCode
                };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception occurred while fetching patient {PatNum}", patNum);
            return new OpenDentalApiResponse<OpenDentalPatient>
            {
                Success = false,
                ErrorMessage = ex.Message,
                StatusCode = 500
            };
        }
    }
    
    public async Task<bool> TestConnectionAsync()
    {
        try
        {
            _logger.LogDebug("Testing OpenDental API connection");
            
            var response = await _httpClient.GetAsync("/api/v1/patients");
            var isSuccess = response.IsSuccessStatusCode;
            
            _logger.LogInformation("OpenDental API connection test {Result}", 
                isSuccess ? "successful" : "failed");
            
            return isSuccess;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "OpenDental API connection test failed");
            return false;
        }
    }
}