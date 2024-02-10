namespace RomanNumbers.Tests;

public class NumberTests
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(5, "V")]
    [InlineData(10, "X")]
    [InlineData(50, "L")]
    [InlineData(100, "C")]
    [InlineData(500, "D")]
    [InlineData(1000, "M")]
    public void GivenASimpleOrdinalNumber_ShouldReturnTheRomanRepresentation(int number, string expected)
    {
        // Arrange
        
        // Act
        var sut = Number.ToRoman(number);
        
        // Assert
        Assert.Equal(expected, sut);
    }

    [Theory]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(9, "IX")]
    [InlineData(11, "XI")]
    [InlineData(42, "XLII")]
    [InlineData(57, "LVII")]
    [InlineData(123, "CXXIII")]
    [InlineData(489, "CDLXXXIX")]
    [InlineData(998, "CMXCVIII")]
    [InlineData(2514, "MMDXIV")]
    [InlineData(3998, "MMMCMXCVIII")]
    [InlineData(3999, "MMMCMXCIX")]
    public void GivenAnUnmappedNumber_ShouldReturnTheRomanRepresentation(int number, string expected)
    {
        // Arrange
        
        // Act
        var sut = Number.ToRoman(number);
        
        // Assert
        Assert.Equal(expected, sut);
    }

    [Theory]
    [InlineData("I", 1)]
    [InlineData("V", 5)]
    [InlineData("X", 10)]
    [InlineData("L", 50)]
    [InlineData("C", 100)]
    [InlineData("D", 500)]
    [InlineData("M", 1000)]
    public void GivenABasicRomanNumber_ShouldReturnTheOrdinalRepresentation(string romanNumber, int expected)
    {
        // Arrange
        
        // Act
        var sut = Number.ToOrdinal(romanNumber);
        
        // Assert
        Assert.Equal(expected, sut);
    }
    
    [Theory]
    [InlineData("II", 2)]
    [InlineData("III", 3)]
    [InlineData("IV", 4)]
    [InlineData("VI", 6)]
    [InlineData("VII", 7)]
    [InlineData("VIII", 8)]
    [InlineData("IX", 9)]
    [InlineData("XXXIV", 34)]
    [InlineData("XLIII", 43)]
    [InlineData("CXXIII", 123)]
    [InlineData("CDLXXXIX", 489)]
    [InlineData("DLXXVI", 576)]
    [InlineData("CMXCVIII", 998)]
    [InlineData("MCCXCIII", 1293)]
    [InlineData("MMMCMXCVIII", 3998)]
    [InlineData("MMMCMXCIX", 3999)]
    public void GivenAComplexRomanNumber_ShouldReturnTheOrdinalRepresentation(string romanNumber, int expected)
    {
        // Arrange
        
        // Act
        var sut = Number.ToOrdinal(romanNumber);
        
        // Assert
        Assert.Equal(expected, sut);
    }

    [Theory]
    [InlineData("IIII", "IV")]
    [InlineData("XXXX", "XL")]
    [InlineData("CCCC", "CD")]
    public void GivenMoreThanThreeCharactersEquals_ShouldConvertToCorrectRepresentation(string input, string expected)
    {
        // Arrange
        
        // Act
        var sut = Number.Transform(input);
        
        // Assert
        Assert.Equal(expected, sut);
    }

    [Theory]
    [InlineData("IIII")]
    [InlineData("XXXX")]
    [InlineData("CCCC")]
    [InlineData("IIIIII")]
    [InlineData("XXXXII")]
    public void GivenAnInvalidRomanNumber_ShouldThrowsAnException(string input)
    {
        // Arrange
        
        // Act
        
        // Assert
        Assert.Throws<ArgumentException>(() => Number.EnsureIsValidRomanNumber(input));
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(0)]
    [InlineData(4000)]
    public void GivenAnInvalidValue_ShouldThrowsAnException(int input)
    {
        // Arrange
        
        // Act
        
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Number.EnsureIsValidOrdinalNumber(input));
    }
}