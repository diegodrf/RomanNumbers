using System.Text.RegularExpressions;

namespace RomanNumbers;

public static partial class Number
{
    private const int MaxNumber = 3999;
    private static readonly Dictionary<int, string> CharactersDictionary = new()
    {
        { 1, "I" },
        { 2, "II" },
        { 3, "III" },
        { 4, "IV" },
        { 5, "V" },
        { 6, "VI" },
        { 7, "VII" },
        { 8, "VIII" },
        { 9, "IX" },
        { 10, "X" },
        { 50, "L" },
        { 100, "C" },
        { 500, "D" },
        { 1000, "M" }
    };
    
    public static string ToRoman(int number)
    {
        EnsureIsValidOrdinalNumber(number);

        if (CharactersDictionary.TryGetValue(number, out var value))
        {
            return value;
        }
        
        var roman = string.Empty;
        var tempNumber = number;
        
        while (true)
        {
            foreach (var key in CharactersDictionary.Keys.OrderByDescending(k => k))
            {
                if (tempNumber - key < 0) continue;
                roman += CharactersDictionary[key];
                roman = Transform(roman);
                tempNumber -= key;
                break;
            }

            if (number == ToOrdinal(Transform(roman))) break;
        }

        return roman;
    }

    public static int ToOrdinal(string romanNumber)
    {
        EnsureIsValidRomanNumber(romanNumber);
        
        if (CharactersDictionary.ContainsValue(romanNumber))
        {
            return CharactersDictionary
                .Single(x => x.Value == romanNumber)
                .Key;
        }

        var characters = romanNumber.ToCharArray();

        var finalNumber = 0;
        var index = 0;
        while (index < characters.Length)
        {
            var currentNumber = ToOrdinal(characters[index].ToString());

            if (index + 1 >= characters.Length)
            {
                finalNumber += currentNumber;
                break;
            }
            
            var nextNumber = ToOrdinal(characters[index + 1].ToString());

            if (currentNumber < nextNumber)
            {
                finalNumber += nextNumber - currentNumber;
                index += 2;
            }
            else
            {
                finalNumber += currentNumber;
                index += 1;
            }
        }
        
        return finalNumber;
    }

    public static void EnsureIsValidOrdinalNumber(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxNumber);
    }
    public static void EnsureIsValidRomanNumber(string input)
    {
        if (RegexI().IsMatch(input)
            || RegexX4().IsMatch(input)
            || RegexC4().IsMatch(input))
        {
            throw new ArgumentException("The roman number representation is not valid.");
        }
    }
    
    public static string Transform(string input)
    {
        if (RegexI().IsMatch(input))
        {
            input = RegexI().Replace(input, "IV");    
        }
        
        if (RegexX4().IsMatch(input))
        {
            input = RegexX4().Replace(input, "XL");    
        }
        
        if (RegexDc4().IsMatch(input))
        {
            input = RegexDc4().Replace(input, "CM");    
        }
        
        if (RegexC4().IsMatch(input))
        {
            input = RegexC4().Replace(input, "CD");    
        }
        
        if (RegexLxl().IsMatch(input))
        {
            input = RegexLxl().Replace(input, "XC");    
        }

        return input;
    }

    [GeneratedRegex("I{4}")]
    private static partial Regex RegexI();
    
    [GeneratedRegex("X{4}")]
    private static partial Regex RegexX4();
    
    [GeneratedRegex("C{4}")]
    private static partial Regex RegexC4();
    
    [GeneratedRegex("DC{4}")]
    private static partial Regex RegexDc4();
    
    [GeneratedRegex("LXL")]
    private static partial Regex RegexLxl();
}