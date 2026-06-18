using DovizCevirici.Domain.Models;
using Newtonsoft.Json;

namespace DovizCevirici.Infrastructure;

/// <summary>
/// Frankfurter API ile HTTP iletiþimini yöneten sýnýftýr.
/// </summary>
public class FrankfurterApiClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://api.frankfurter.dev/v2/rates";

    /// <summary>
    /// FrankfurterApiClient sýnýfýnýn yeni bir örneðini oluþturur.
    /// </summary>
    public FrankfurterApiClient()
    {
        _httpClient = new HttpClient();
    }

    /// <summary>
    /// Kaynak ve hedef para birimine göre Frankfurter API'den kur deðerini getirir.
    /// </summary>
    /// <param name="sourceCurrency">Kaynak para birimi.</param>
    /// <param name="targetCurrency">Hedef para birimi.</param>
    /// <returns>Kaynak para biriminin hedef para birimi karþýsýndaki kur deðeri.</returns>
    /// <exception cref="Exception">API isteði baþarýsýz olduðunda veya kur bilgisi okunamadýðýnda fýrlatýlýr.</exception>
    public async Task<decimal> GetRateAsync(string sourceCurrency, string targetCurrency)
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
}