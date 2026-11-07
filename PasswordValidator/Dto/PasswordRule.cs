namespace PasswordValidator.Dto;

/// <summary>
/// A new password validation rule.
/// </summary>
/// <param name="Name">
/// The name of the validation rule.
/// </param>
/// <param name="ErrorMessage">
/// Error message returned when validation fails.
/// </param>
/// <param name="isValid">
/// Check which must be true to pass the validation.
/// </param>
public class PasswordRule {
    public required string Name { get; init; }
    public required string ErrorMessage { get; init; }
    public required Func<string, bool> IsValid { get; init; }
}