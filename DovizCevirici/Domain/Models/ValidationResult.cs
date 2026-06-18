namespace DovizCevirici.Domain.Models;

/// <summary>
/// Represents the result of an input validation operation.
/// </summary>
public class ValidationResult
{
    /// <summary>
    /// Indicates whether the validation result is valid.
    /// </summary>
    public bool IsValid { get; private set; }

    /// <summary>
    /// Error message shown when validation fails.
    /// </summary>
    public string ErrorMessage { get; private set; } = string.Empty;

    /// <summary>
    /// Creates a successful validation result.
    /// </summary>
    public static ValidationResult Success()
    {
        return new ValidationResult
        {
            IsValid = true
        };
    }

    /// <summary>
    /// Creates a failed validation result with an error message.
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