using System.Text.RegularExpressions;

namespace AuthService.Common;

public interface IPasswordValidator
{
    bool Validate(string password);
}

public class PasswordValidator : IPasswordValidator
{
    private readonly PasswordEntropyValidator _entropyValidator = new(25, 2);
    
    public bool Validate(string password)
    {
        // TODO: Check against previous used passwords variations
        // TODO: Check against pwned passwords
        return _entropyValidator.Validate(password);
    }
}

public class PasswordEntropyValidator
{
    private readonly double _minEntropy;
    private readonly int _maxSequenceLength;

    public PasswordEntropyValidator(double minEntropy, int maxSequenceLength)
    {
        _minEntropy = minEntropy;
        _maxSequenceLength = maxSequenceLength;
    }

    public bool Validate(string password)
    {
        // Remove sequences from the password
        var passwordWithoutSequences = RemoveSequences(password);

        // Calculate the entropy of the password without sequences
        var entropy = CalculateEntropy(passwordWithoutSequences);

        return entropy >= _minEntropy;
    }
    
    private double CalculateEntropy(string password)
    {
        var uniqueCharacters = (new HashSet<char>(password)).Count;
        
        var entropy = Math.Log(uniqueCharacters, 2) * password.Length;

        return entropy;
    }
    
    private string RemoveSequences(string password)
    {
        var pattern = @"(\w)\1{" + (_maxSequenceLength - 1) + @",}";
        
        var passwordWithoutSequences = Regex.Replace(password, pattern, "");

        return passwordWithoutSequences;
    }
}