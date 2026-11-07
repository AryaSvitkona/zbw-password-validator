// ============================================================
// AUFTRAG 2 – PasswortValidator (⭐⭐ Mittel | ~30 Min.)
//
// Validiert ein Passwort und fordert erneute Eingabe per do-while.
//
// Anforderungen:
//   - do-while-Schleife: solange Passwort ungültig
//   - gültig: mindestens 8 Zeichen UND mindestens eine Ziffer
//   - Ziffer mit foreach über die Zeichen + char.IsDigit(...) suchen
//   - Fehlermeldung: was fehlt
// ============================================================


using PasswordValidator.Dto;

PasswortValidator.Start();

public static class PasswortValidator {
    public static void Start() {
        
        PasswordRule[] rules = [
            new PasswordRule {
                Name = "minLength",
                ErrorMessage = "Password must contain at least 8 characters.",
                IsValid = password => password.Length >= 8
            },

            new PasswordRule {
                Name = "hasDigit",
                ErrorMessage = "Password must contain at least one digit.",
                IsValid = password => {
                    foreach (char character in password) {
                        if (char.IsDigit(character)) {
                            return true;
                        }
                    }

                    return false;
                }
            }
        ];

        PasswordValidationResult? result = null;

        do {
            Console.WriteLine("Choose password. Criteria: 1 number, min 8 characters");
            string password = Console.ReadLine() ?? "";

            result = ValidatePassword(password, rules);

            if (!result.IsValid) {
                foreach (string errorMessage in result.ErrorMessages) {
                    Console.WriteLine(errorMessage);
                }
            }
        } while (!result.IsValid);

        Console.WriteLine("Password is valid.");
    }

    private static PasswordValidationResult ValidatePassword(string password, PasswordRule[] rules) {
        List<string> violatedRuleNames = [];
        List<string> errorMessages = [];

        foreach (PasswordRule rule in rules) {
            if (!rule.IsValid(password)) {
                violatedRuleNames.Add(rule.Name);
                errorMessages.Add(rule.ErrorMessage);
            }
        }

        return new PasswordValidationResult {
            IsValid = violatedRuleNames.Count == 0,
            ViolatedRuleNames = violatedRuleNames.ToArray(),
            ErrorMessages = errorMessages.ToArray()
        };
    }
}