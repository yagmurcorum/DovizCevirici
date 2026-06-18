namespace DovizCevirici.Domain.Models;

/// <summary>
/// Represents a single exchange rate record returned from the Frankfurter API.
/// </summary>
public class ExchangeRateResponse
{
    /// <summary>
    /// Date of the exchange rate.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Source currency code.
    /// </summary>
    public string Base { get; set; } = string.Empty;

    /// <summary>
    /// Target currency code.
    /// </summary>
    public string Quote { get; set; } = string.Empty;

    /// <summary>
    /// Exchange rate value between source and target currency.
    /// </summary>
    public decimal Rate { get; set; }
}