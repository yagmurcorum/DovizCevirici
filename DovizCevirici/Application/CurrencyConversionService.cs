using DovizCevirici.Domain.Models;
using DovizCevirici.Infrastructure;

namespace DovizCevirici.Application;

/// <summary>
/// Manages the currency conversion workflow.
/// </summary>
public class CurrencyConversionService
{
    private readonly FrankfurterApiClient _apiClient;

    /// <summary>
    /// Creates a new instance of the CurrencyConversionService class.
    /// </summary>
    public CurrencyConversionService()
    {
        _apiClient = new FrankfurterApiClient();
    }

    /// <summary>
    /// Validates the conversion request, gets the exchange rate from the API and calculates the converted amount.
    /// </summary>
    /// <param name="request">Currency conversion request.</param>
    /// <returns>Currency conversion result.</returns>
    /// <exception cref="Exception">Thrown when validation fails or exchange rate cannot be received.</exception>
    public async Task<ConversionResult> ConvertAsync(ConversionRequest request)
    {
        ValidationResult validationResult = ValidateRequest(request);

        if (!validationResult.IsValid)
        {
            throw new Exception(validationResult.ErrorMessage);
        }

        decimal rate = await _apiClient.GetRateAsync(
            request.SourceCurrency,
            request.TargetCurrency);

        decimal convertedAmount = request.Amount * rate;

        return new ConversionResult
        {
            SourceCurrency = request.SourceCurrency,
            TargetCurrency = request.TargetCurrency,
            Amount = request.Amount,
            Rate = rate,
            ConvertedAmount = convertedAmount
        };
    }

    /// <summary>
    /// Validates the currency conversion request.
    /// </summary>
    /// <param name="request">Currency conversion request to validate.</param>
    /// <returns>Validation result.</returns>
    private ValidationResult ValidateRequest(ConversionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.SourceCurrency))
        {
            return ValidationResult.Failure("Kaynak para birimi secilmelidir.");
        }

        if (string.IsNullOrWhiteSpace(request.TargetCurrency))
        {
            return ValidationResult.Failure("Hedef para birimi secilmelidir.");
        }

        if (request.Amount <= 0)
        {
            return ValidationResult.Failure("Tutar sifirdan buyuk olmalidir.");
        }

        if (request.SourceCurrency == request.TargetCurrency)
        {
            return ValidationResult.Failure("Kaynak ve hedef para birimi ayni olamaz.");
        }

        return ValidationResult.Success();
    }
}