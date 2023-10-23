namespace LinkedOut.Tests;

public class UnitTest1
{
    [Fact] //Attribute
    public void CanAddTwoIntegers()
    {
        //Given
        int a = 10;
        int b = 20;
        int total;

        //When - "Act" - Poke at it and see what happens
        total = a + b; // "System Under Test" ("SUT")

        //Then - Assert - Find out

        Assert.Equal(30, total);
    }

    [Theory]
    //the parameters of inlinedata are based on the following function number of paramenters values
    [InlineData(10, 20, 30)]
    //we use theory when we get literals as outputs
    public void CanAddAnyTwoIntegers(int a, int b, int expected)
    {
        int total = a + b;
        Assert.Equal(expected, total);
    }

    [Fact]
    public void CanFormatNames()
    {
        //Given
        NameFormatter formatter = new NameFormatter();

        //When
        string fullName = formatter.FormatName("Han", "Solo");

        Assert.Equal("Solo, Han", fullName);
    }
}

public class NameFormatter
{
    public string FormatName(string firstName, string lastName)
    {
        return lastName + ", " + firstName;
    }
}