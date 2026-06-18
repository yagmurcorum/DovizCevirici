namespace DovizCevirici.Domain.Models;

/// <summary>
/// Frankfurter API'den dönen tek bir döviz kuru kaydını temsil eder.
/// </summary>
public class ExchangeRateResponse
{
    /// <summary>
    /// Kur bilgisinin ait olduğu tarih.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Kaynak para birimi.
    /// </summary>
    public string Base { get; set; } = string.Empty;

    /// <summary>
    /// Hedef para birimi.
    /// </summary>
    public string Quote { get; set; } = string.Empty;

    /// <summary>
    /// Kaynak para biriminin hedef para birimi karşısındaki kur değeri.
    /// </summary>
    public decimal Rate { get; set; }
}