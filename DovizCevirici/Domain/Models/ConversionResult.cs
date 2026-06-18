namespace DovizCevirici.Domain.Models;

/// <summary>
/// Döviz çevirme iþlemi sonucunda oluþan bilgileri temsil eder.
/// </summary>
public class ConversionResult
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
    /// Kullanýcýnýn girdiði tutar.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// API'den alýnan kur deðeri.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Hesaplanan dönüþüm sonucu.
    /// </summary>
    public decimal ConvertedAmount { get; set; }

    /// <summary>
    /// Kullanýcýya gösterilecek sonuç metni.
    /// </summary>
    public string DisplayText =>
        $"{Amount:N2} {SourceCurrency} = {ConvertedAmount:N2} {TargetCurrency}";
}