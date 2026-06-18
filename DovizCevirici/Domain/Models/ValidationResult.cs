namespace DovizCevirici.Domain.Models;

/// <summary>
/// Kullanýcý giriþlerinin geçerlilik sonucunu temsil eder.
/// </summary>
public class ValidationResult
{
    /// <summary>
    /// Ýþlemin geçerli olup olmadýðýný belirtir.
    /// </summary>
    public bool IsValid { get; private set; }

    /// <summary>
    /// Geçersiz durumda kullanýcýya gösterilecek hata mesajý.
    /// </summary>
    public string ErrorMessage { get; private set; } = string.Empty;

    /// <summary>
    /// Baþarýlý validation sonucu oluþturur.
    /// </summary>
    public static ValidationResult Success()
    {
        return new ValidationResult
        {
            IsValid = true
        };
    }

    /// <summary>
    /// Hatalý validation sonucu oluþturur.
    /// </summary>
    public static ValidationResult Failure(string errorMessage)
    {
        return new ValidationResult
        {
            IsValid = false,
            ErrorMessage = errorMessage
        };
    }
}