namespace DovizCevirici.Domain.Models;

/// <summary>
/// Kullanýcýnýn döviz çevirme isteðini temsil eder.
/// </summary>
public class ConversionRequest
{
    /// <summary>
    /// Kaynak para birimi.
    /// </summary>
    public string SourceCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Hedef para birimi.
    /// </summary>
    public string TargetCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Kullanýcýnýn çevirmek istediði tutar.
    /// </summary>
    public decimal Amount { get; set; }
}