using DovizCevirici.Domain.Models;
using DovizCevirici.Infrastructure;

namespace DovizCevirici.Application;

/// <summary>
/// Döviz çevirme iþ akýþýný yöneten servis sýnýfýdýr.
/// </summary>
public class CurrencyConversionService
{
    private readonly FrankfurterApiClient _apiClient;

    /// <summary>
    /// CurrencyConversionService sýnýfýnýn yeni bir örneðini oluþturur.
    /// </summary>
    public CurrencyConversionService()
    {
        _apiClient = new FrankfurterApiClient();
    }

    /// <summary>
    /// Kullanýcýnýn döviz çevirme isteðini doðrular, API'den kur bilgisini alýr ve dönüþüm sonucunu hesaplar.
    /// </summary>
    /// <param name="request">Döviz çevirme isteði.</param>
    /// <returns>Döviz çevirme iþlemi sonucunda oluþan sonuç bilgisi.</returns>
    /// <exception cref="Exception">Kullanýcý giriþi geçersiz olduðunda veya API'den kur bilgisi alýnamadýðýnda fýrlatýlýr.</exception>
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
    /// Döviz çevirme isteðinin geçerli olup olmadýðýný kontrol eder.
    /// </summary>
    /// <param name="request">Kontrol edilecek döviz çevirme isteði.</param>
    /// <returns>Validation sonucu.</returns>
    private ValidationResult ValidateRequest(ConversionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.SourceCurrency))
        {
            return ValidationResult.Failure("Kaynak para birimi seçilmelidir.");
        }

        if (string.IsNullOrWhiteSpace(request.TargetCurrency))
        {
            return ValidationResult.Failure("Hedef para birimi seçilmelidir.");
        }

        if (request.Amount <= 0)
        {
            return ValidationResult.Failure("Tutar sýfýrdan büyük olmalýdýr.");
        }

        if (request.SourceCurrency == request.TargetCurrency)
        {
            return ValidationResult.Failure("Kaynak ve hedef para birimi ayný olamaz.");
        }

        return ValidationResult.Success();
    }
}