namespace MyProject.Test;

public class InlineDataTest
{
    [Theory]
    [InlineData(2, 2)]
    [InlineData(5, 5)]
    [InlineData(20, 20)]
    public void Should_be_equal(int firstNumber, int secondNumber) => Assert.Equal(firstNumber, secondNumber);
}