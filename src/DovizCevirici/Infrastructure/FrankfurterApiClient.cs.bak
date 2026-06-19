using DovizCevirici.Domain.Models;
using Newtonsoft.Json;

namespace DovizCevirici.Infrastructure;

/// <summary>
/// Handles HTTP communication with the Frankfurter API.
/// </summary>
public class FrankfurterApiClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://api.frankfurter.dev/v2/rates";

    /// <summary>
    /// Creates a new instance of the FrankfurterApiClient class.
    /// </summary>
    public FrankfurterApiClient()
    {
        _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };
    }

    /// <summary>
    /// Gets the exchange rate value for the selected source and target currency.
    /// </summary>
    /// <param name="sourceCurrency">Source currency code.</param>
    /// <param name="targetCurrency">Target currency code.</param>
    /// <returns>Exchange rate value between source and target currency.</returns>
    /// <exception cref="Exception">Thrown when the API request fails or rate value cannot be read.</exception>
    public async Task<decimal> GetRateAsync(string sourceCurrency, string targetCurrency)
    {
        try
        {
            string requestUrl = $"{BaseUrl}?base={sourceCurrency}&quotes={targetCurrency}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Döviz kuru bilgisi alýnýrken API isteði baþarýsýz oldu.");
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();

            List<ExchangeRateResponse>? rates =
                JsonConvert.DeserializeObject<List<ExchangeRateResponse>>(jsonResponse);

            ExchangeRateResponse? rateResponse = rates?.FirstOrDefault();

            if (rateResponse == null || rateResponse.Rate <= 0)
            {
                throw new Exception("API yanýtýndan geçerli kur bilgisi okunamadý.");
            }

            return rateResponse.Rate;
        }
        catch (HttpRequestException)
        {
            throw new Exception("API baðlantýsý sýrasýnda bir sorun oluþtu. Lütfen internet baðlantýnýzý kontrol edin.");
        }
        catch (TaskCanceledException)
        {
            throw new Exception("API isteði zaman aþýmýna uðradý. Lütfen tekrar deneyin.");
        }
        catch (JsonException)
        {
            throw new Exception("API yanýtý beklenen formatta okunamadý.");
        }
    }
}