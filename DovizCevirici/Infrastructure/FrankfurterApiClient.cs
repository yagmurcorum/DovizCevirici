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
        _httpClient = new HttpClient();
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
        string requestUrl = $"{BaseUrl}?base={sourceCurrency}&quotes={targetCurrency}";

        HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Doviz kuru bilgisi alinirken API istegi basarisiz oldu.");
        }

        string jsonResponse = await response.Content.ReadAsStringAsync();

        List<ExchangeRateResponse>? rates =
            JsonConvert.DeserializeObject<List<ExchangeRateResponse>>(jsonResponse);

        ExchangeRateResponse? rateResponse = rates?.FirstOrDefault();

        if (rateResponse == null || rateResponse.Rate <= 0)
        {
            throw new Exception("API yanitindan gecerli kur bilgisi okunamadi.");
        }

        return rateResponse.Rate;
    }
}