
namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    public void SingleDigit(string input, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("123", 123)]
    public void NoDelimeterString(string input, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,1,1", 3)]
    [InlineData("1,2,3,4,5", 15)]
    [InlineData("2,2", 4)]
    public void CommaDelimiterString(string input, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,1,1", 3)]
    [InlineData("1,2\n2,3,4,5", 17)]
    public void ArbitraryDelimiterString(string input, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }
}
