namespace DovizCevirici.Domain.Models;

/// <summary>
/// Represents the user's currency conversion request.
/// </summary>
public class ConversionRequest
{
    /// <summary>
    /// Source currency selected by the user.
    /// </summary>
    public string SourceCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Target currency selected by the user.
    /// </summary>
    public string TargetCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Amount entered by the user.
    /// </summary>
    public decimal Amount { get; set; }
}