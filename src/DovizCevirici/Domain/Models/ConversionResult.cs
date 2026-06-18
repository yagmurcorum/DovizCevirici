namespace DovizCevirici.Domain.Models;

/// <summary>
/// Represents the result of a currency conversion operation.
/// </summary>
public class ConversionResult
{
    /// <summary>
    /// Source currency used in the conversion.
    /// </summary>
    public string SourceCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Target currency used in the conversion.
    /// </summary>
    public string TargetCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Original amount entered by the user.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Exchange rate value received from the API.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Calculated converted amount.
    /// </summary>
    public decimal ConvertedAmount { get; set; }

    /// <summary>
    /// Text that will be shown to the user.
    /// </summary>
    public string DisplayText =>
        $"{Amount:N2} {SourceCurrency} = {ConvertedAmount:N2} {TargetCurrency}";
}