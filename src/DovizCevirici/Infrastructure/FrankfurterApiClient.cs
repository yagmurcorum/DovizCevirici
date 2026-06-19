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
                throw new Exception("Döviz kuru bilgisi alınırken API isteği başarısız oldu.");
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();

            List<ExchangeRateResponse>? rates =
                JsonConvert.DeserializeObject<List<ExchangeRateResponse>>(jsonResponse);

            ExchangeRateResponse? rateResponse = rates?.FirstOrDefault();

            if (rateResponse == null || rateResponse.Rate <= 0)
            {
                throw new Exception("API yanıtından geçerli kur bilgisi okunamadı.");
            }

            return rateResponse.Rate;
        }
        catch (HttpRequestException)
        {
            throw new Exception("API bağlantısı sırasında bir sorun oluştu. Lütfen internet bağlantınızı kontrol edin.");
        }
        catch (TaskCanceledException)
        {
            throw new Exception("API isteği zaman aşımına uğradı. Lütfen tekrar deneyin.");
        }
        catch (JsonException)
        {
            throw new Exception("API yanıtı beklenen formatta okunamadı.");
        }
    }
    /// <summary>
    /// Gets exchange rate records for multiple target currencies.
    /// </summary>
    /// <param name="sourceCurrency">Source currency code.</param>
    /// <param name="targetCurrencies">Target currency codes.</param>
    /// <returns>Exchange rate response list.</returns>
    /// <exception cref="Exception">Thrown when the API request fails or response cannot be read.</exception>
    public async Task<List<ExchangeRateResponse>> GetRatesAsync(
        string sourceCurrency,
        string[] targetCurrencies)
    {
        try
        {
            string quotes = string.Join(",", targetCurrencies);
            string requestUrl = $"{BaseUrl}?base={sourceCurrency}&quotes={quotes}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Döviz kuru listesi alınırken API isteği başarısız oldu.");
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();

            List<ExchangeRateResponse>? rates =
                JsonConvert.DeserializeObject<List<ExchangeRateResponse>>(jsonResponse);

            if (rates == null || rates.Count == 0)
            {
                throw new Exception("API yanıtından geçerli kur listesi okunamadı.");
            }

            return rates;
        }
        catch (HttpRequestException)
        {
            throw new Exception("API bağlantısı sırasında bir sorun oluştu. Lütfen internet bağlantınızı kontrol edin.");
        }
        catch (TaskCanceledException)
        {
            throw new Exception("API isteği zaman aşımına uğradı. Lütfen tekrar deneyin.");
        }
        catch (JsonException)
        {
            throw new Exception("API yanıtı beklenen formatta okunamadı.");
        }
    }
}