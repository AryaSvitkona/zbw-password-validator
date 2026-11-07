namespace PasswordValidator.Dto;

/// <summary>
/// A new password validation result.
/// </summary>
/// <param name="isValid">
/// Boolean with the state of the validation.
/// </param>
/// <param name="ErrorMessages">
/// List of error messages which were violated.
/// </param>
/// <param name="ViolatedRuleNames">
/// Rules which were violated.
/// </param>
public class PasswordValidationResult {
    public bool IsValid { get; init; }

    public required string[] ViolatedRuleNames { get; init; }

    public required string[] ErrorMessages { get; init; }
}